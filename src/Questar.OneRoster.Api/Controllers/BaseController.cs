namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net;
    using System.Net.Mime;
    using System.Reflection;
    using System.Threading.Tasks;
    using DataServices;
    using Filtering;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Newtonsoft.Json;
    using OneRoster.Models;
    using OneRoster.Models.Errors;
    using Serialization;
    using Sorting;

    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : Base
    {
        protected static readonly HashSet<string> Properties =
            new HashSet<string>(typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(info => info.Name), StringComparer.OrdinalIgnoreCase);

        protected BaseController(IOneRosterWorkspace workspace)
        {
            Workspace = workspace;
        }

        protected IOneRosterWorkspace Workspace { get; }

        [NonAction]
        protected abstract IQuery<T> Query();

        [HttpGet]
        public virtual async Task<ActionResult<dynamic>> Select(SelectRequest request)
        {
            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings { ContractResolver = resolver };

            var statuses = new StatusInfoList();
            var result = new OneRosterCollection<dynamic>
            {
                StatusInfoSet = statuses
            };

            var fields =
                request.Fields?
                    .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            if (fields != null)
                if (fields.Any())
                    statuses.AddRange(fields
                        .Where(field => !Properties.Contains(field))
                        .Select(StatusInfo.InvalidSelectionField));
                else
                    statuses.Add(StatusInfo.InvalidBlankSelectionField());

            var filter = request.Filter != null ? Filter.Parse(request.Filter) : null;
            if (filter != null)
                statuses.AddRange(filter
                    .GetProperties()
                    .Select(property => property.Name)
                    .Where(property => !Properties.Contains(property))
                    .Select(StatusInfo.InvalidFilterField));

            var sortName = request.Sort;
            var sortDirection = request.OrderBy;
            if (sortName != null && !Properties.Contains(sortName))
            {
                statuses.Add(StatusInfo.InvalidSortField(sortName));
                sortName = nameof(Base.SourcedId);
                sortDirection = default(SortDirection);
            }

            var pageLimit = request.Limit;
            if (pageLimit < 0)
                statuses.Add(StatusInfo.InvalidLimitField());

            var pageOffset = request.Offset;
            if (pageOffset < 0)
                statuses.Add(StatusInfo.InvalidOffsetField());

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(JsonConvert.SerializeObject(result, settings));

            IQuery query = Query();

            // filter, only if requested
            if (filter != null)
                query = query.Where(filter);

            // always sort, so that we may paginate
            query = query.Sort(sortName ?? nameof(Base.SourcedId), sortDirection);

            // dynamic select, after sorting, only if requested
            var selectors = fields?.Where(field => Properties.Contains(field)).ToList();
            if (selectors != null)
                query = query.Select(selectors);

            var data = await query.ToPageAsync(pageOffset, pageLimit);
            var count = data.Count;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkFactory = new LinkHeaderFactory(HttpContext);
            var link = linkFactory.Create(pageOffset, pageLimit, count);
            if (!string.IsNullOrEmpty(link))
                HttpContext.Response.Headers.Add("Link", link);

            result.Results = data.Items.OfType<dynamic>().ToArray();

            var content = JsonConvert.SerializeObject(result, settings);

            return Content(content, "application/json");
        }

        [HttpGet("{SourcedId}")]
        public virtual async Task<ActionResult<dynamic>> Single(SingleRequest request)
        {
            var resolver = new OneRosterContractResolver(typeof(T));
            var settings = new JsonSerializerSettings { ContractResolver = resolver };

            var statuses = new StatusInfoList();
            var result = new OneRosterSingle<dynamic>
            {
                StatusInfoSet = statuses
            };

            var fields =
                request.Fields?
                    .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            if (fields != null)
                if (fields.Any())
                    statuses.AddRange(fields
                        .Where(field => !Properties.Contains(field))
                        .Select(StatusInfo.InvalidSelectionField));
                else
                    statuses.Add(StatusInfo.InvalidBlankSelectionField());

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(JsonConvert.SerializeObject(result, settings));

            IQuery query = Query().WhereHasKey(request.SourcedId);

            // dynamic select, only if requested
            var selectors = fields?.Where(field => Properties.Contains(field)).ToList();
            if (selectors != null)
                query = query.Select(selectors);

            var data = await query.SingleAsync();

            result.Result = data;

            var content = JsonConvert.SerializeObject(result, settings);

            return Content(content, "application/json");
        }

        // IUpsertable<T>
        //[HttpPut("{id}")]
        //public virtual async Task<ActionResult<UpsertResponse<T>>> Upsert(UpsertRequest<T> request) => throw new NotImplementedException();

        // IDeletable<T>
        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}