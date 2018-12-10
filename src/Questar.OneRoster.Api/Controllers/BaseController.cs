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
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;
    using OneRoster.Models.Errors;

    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : Base
    {
        protected static readonly HashSet<string> Properties =
            new HashSet<string>(typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(info => info.Name), StringComparer.OrdinalIgnoreCase);

        protected BaseController(IWorkspace workspace) => Workspace = workspace;

        protected IWorkspace Workspace { get; }

        [HttpGet]
        public virtual async Task<ActionResult<SelectResponse>> Select(SelectRequest request)
        {
            var statuses = new StatusInfoList();

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
                return BadRequest(new SelectResponse { StatusInfo = statuses });

            var query = Workspace.GetRepository<T>().AsQuery();
            var query1 = filter == null ? query : query.Where(filter.ToFilterExpression<T>());
            var query2 = query1.Sort(sortName ?? nameof(Base.SourcedId), sortDirection);
            var query3 = fields == null ? (IOrderedQuery) query2 : query2.Fields(fields);
            var data = await query3.ToPageAsync(pageOffset, pageLimit);
            var count = data.Count;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkFactory = new OneRosterLinkHeaderFactory(HttpContext);
            var link = linkFactory.Create(pageOffset, pageLimit, count);
            if (!string.IsNullOrEmpty(link))
                HttpContext.Response.Headers.Add("Link", link);

            return Ok(new SelectResponse { Data = data }); // TODO data name
        }

        [HttpGet("{SourcedId}")]
        public virtual async Task<ActionResult<SingleResponse>> Single(SingleRequest request)
        {
            var statuses = new StatusInfoList();

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
                return BadRequest(new SingleResponse { StatusInfo = statuses });

            var query = Workspace.GetRepository<T>().AsQuery();
            var query1 = query.WhereHasKey(request.SourcedId); // query.Where(x => x.SourcedId == request.SourcedId);
            var query2 = fields == null ? (IQuery) query1 : query1.Fields(fields);
            var data = await query2.SingleAsync();

            return Ok(new SingleResponse { Data = data }); // TODO data name
        }

        // IUpsertable<T>
        //[HttpPut("{id}")]
        //public virtual async Task<ActionResult<UpsertResponse<T>>> Upsert(UpsertRequest<T> request) => throw new NotImplementedException();

        // IDeletable<T>
        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}