namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using DataServices;
    using Filtering;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using OneRoster.Models;
    using OneRoster.Models.Errors;
    using Serialization;
    using Sorting;

    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : Base
    {
        protected BaseController(IOneRosterWorkspace workspace) =>
            Workspace = workspace;

        protected IOneRosterWorkspace Workspace { get; }

        [NonAction]
        protected abstract IQuery<T> Query();

        [NonAction]
        protected async Task<ActionResult<dynamic>> Select<TSource>(Func<IQuery<TSource>> querier, SelectParams @params)
        {
            var properties =
                new HashSet<string>(typeof(TSource)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(info => info.Name), StringComparer.OrdinalIgnoreCase);
            var resolver = new OneRosterContractResolver(typeof(TSource));
            var settings = new JsonSerializerSettings { ContractResolver = resolver, Converters = { new StringEnumConverter() } };

            var statuses = new StatusInfoList();
            var result = new OneRosterCollection<dynamic> { StatusInfoSet = statuses };

            var fields =
                @params.Fields?
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            if (fields != null)
                if (fields.Any())
                    statuses.AddRange(fields
                        .Where(field => !properties.Contains(field))
                        .Select(StatusInfo.InvalidSelectionField));
                else
                    statuses.Add(StatusInfo.InvalidBlankSelectionField());

            var filter = @params.Filter != null ? Filter.Parse(@params.Filter) : null;
            if (filter != null)
                statuses.AddRange(filter
                    .GetProperties()
                    .Select(property => property.Name)
                    .Where(property => !properties.Contains(property))
                    .Select(StatusInfo.InvalidFilterField));

            var sortName = @params.Sort;
            var sortDirection = @params.OrderBy;
            if (sortName != null && !properties.Contains(sortName))
            {
                statuses.Add(StatusInfo.InvalidSortField(sortName));
                sortName = nameof(Base.SourcedId);
                sortDirection = default(SortDirection);
            }

            var pageLimit = @params.Limit;
            if (pageLimit < 0)
                statuses.Add(StatusInfo.InvalidLimitField());

            var pageOffset = @params.Offset;
            if (pageOffset < 0)
                statuses.Add(StatusInfo.InvalidOffsetField());

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(JsonConvert.SerializeObject(result, settings));

            IQuery query = querier();

            // filter, only if requested
            if (filter != null)
                query = query.Where(filter);

            // always sort, so that we may paginate
            query = query.Sort(sortName ?? nameof(Base.SourcedId), sortDirection);

            // dynamic select, after sorting, only if requested
            var selectors = fields?.Where(properties.Contains).ToList();
            if (selectors != null)
                query = query.Select(selectors);

            var data = await query.ToPageAsync(pageOffset, pageLimit);
            var count = data.Count;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkFactory = Request.HttpContext.RequestServices.GetService<LinkHeaderFactory>();
            var link = linkFactory.Create(pageOffset, pageLimit, count);
            if (!string.IsNullOrEmpty(link))
                HttpContext.Response.Headers.Add("Link", link);

            result.Results = data.Items.OfType<dynamic>().ToArray();

            var content = JsonConvert.SerializeObject(result, Formatting.Indented, settings);

            return Content(content);
        }

        [NonAction]
        protected virtual async Task<ActionResult<dynamic>> Single<TSource>(Func<IQuery<TSource>> querier, SingleParams @params)
        {
            var properties =
                new HashSet<string>(typeof(TSource)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(info => info.Name), StringComparer.OrdinalIgnoreCase);
            var resolver = new OneRosterContractResolver(typeof(TSource));
            var settings = new JsonSerializerSettings { ContractResolver = resolver, Converters = { new StringEnumConverter() } };

            var statuses = new StatusInfoList();
            var result = new OneRosterSingle<dynamic> { StatusInfoSet = statuses };

            var fields =
                @params.Fields?
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            if (fields != null)
                if (fields.Any())
                    statuses.AddRange(fields
                        .Where(field => !properties.Contains(field))
                        .Select(StatusInfo.InvalidSelectionField));
                else
                    statuses.Add(StatusInfo.InvalidBlankSelectionField());

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(JsonConvert.SerializeObject(result, settings));

            IQuery query = querier().WhereHasSourcedId(@params.SourcedId);

            // dynamic select, only if requested
            var selectors = fields?.Where(field => properties.Contains(field)).ToList();
            if (selectors != null)
                query = query.Select(selectors);

            var data = await query.SingleAsync();

            result.Result = data;

            var content = JsonConvert.SerializeObject(result, Formatting.Indented, settings);

            return Content(content);
        }

        [HttpGet]
        public virtual Task<ActionResult<dynamic>> Select(SelectParams @params) =>
            Select(Query, @params);

        [HttpGet("{SourcedId}")]
        public virtual Task<ActionResult<dynamic>> Single(SingleParams @params) =>
            Single(Query, @params);
    }
}