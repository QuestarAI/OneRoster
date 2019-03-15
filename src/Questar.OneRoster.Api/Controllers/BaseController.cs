namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using DataServices;
    using Filtering;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;
    using OneRoster.Models.Errors;

    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : Base
    {
        protected const string StatusInfoSet = "StatusInfoSet";

        protected static readonly HashSet<string> Properties =
            new HashSet<string>(typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(info => info.Name), StringComparer.OrdinalIgnoreCase);

        protected BaseController(IWorkspace workspace, BaseControllerOptions options)
        {
            Workspace = workspace;
            Options = options;
        }

        public BaseControllerOptions Options { get; }

        protected IWorkspace Workspace { get; }

        [HttpGet]
        public virtual async Task<ActionResult<dynamic>> Select(SelectRequest request)
        {
            var result = (IDictionary<string, object>) new ExpandoObject();
            var statuses = (StatusInfoList) (result[StatusInfoSet] = new StatusInfoList());

            var fields = request.Fields?
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
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
                statuses.Add(StatusInfo.InvalidSortField(sortName));

            var pageLimit = request.Limit;
            if (pageLimit < 0)
                statuses.Add(StatusInfo.InvalidLimitField());

            var pageOffset = request.Offset;
            if (pageOffset < 0)
                statuses.Add(StatusInfo.InvalidOffsetField());

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(result);

            IQuery query =
                Workspace
                    .GetRepository<T>()
                    .AsQuery();

            // filter, only if requested
            if (filter != null) query = query.Where(filter);

            // always sort, so that we may paginate
            query = query.Sort(sortName ?? nameof(Base.SourcedId), sortDirection);

            // dynamic select, after sorting, only if requested
            if (fields != null) query = query.Select(fields);

            var data = await query.ToPageAsync(pageOffset, pageLimit);
            var count = data.Count;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkFactory = new LinkHeaderFactory(HttpContext);
            var link = linkFactory.Create(pageOffset, pageLimit, count);
            if (!string.IsNullOrEmpty(link))
                HttpContext.Response.Headers.Add("Link", link);

            result[Options.Plural] = data.Items;

            return Ok(result); // TODO data name
        }

        [HttpGet("{SourcedId}")]
        public virtual async Task<ActionResult<dynamic>> Single(SingleRequest request)
        {
            var result = (IDictionary<string, object>) new ExpandoObject();
            var statuses = (StatusInfoList) (result[StatusInfoSet] = new StatusInfoList());

            var fields = request.Fields?
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
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
                return BadRequest(result);

            IQuery query =
                Workspace
                    .GetRepository<T>()
                    .AsQuery()
                    .WhereHasKey(request.SourcedId);

            // dynamic select, only if requested
            if (fields != null) query = query.Select(fields);

            var data = await query.SingleAsync();

            result[Options.Singular] = data;

            return Ok(result); // TODO data name
        }

        // IUpsertable<T>
        //[HttpPut("{id}")]
        //public virtual async Task<ActionResult<UpsertResponse<T>>> Upsert(UpsertRequest<T> request) => throw new NotImplementedException();

        // IDeletable<T>
        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}