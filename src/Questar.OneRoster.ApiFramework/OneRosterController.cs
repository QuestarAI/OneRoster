namespace Questar.OneRoster.ApiFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Data;
    using Filtering;
    using Microsoft.AspNetCore.Mvc;
    using Models.Errors;
    using Reflection;
    using Requests;
    using Responses;

    [Produces("application/json")]
    public abstract class OneRosterController<T> : ControllerBase where T : Base
    {
        protected OneRosterController(IWorkspace workspace) => Workspace = workspace;

        protected IWorkspace Workspace { get; }

        [HttpGet]
        public virtual async Task<ActionResult<SelectResponse<T>>> Select(SelectRequest request)
        {
            // TODO if (!ModelState.IsValid)

            var fields = request.Fields?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(field => field.Trim()).ToList().AsReadOnly();
            var filter = request.Filter != null ? Filter.Parse(request.Filter) : null;
            var pageOffset = request.Offset;
            var pageLimit = request.Limit;
            var sortField = request.Sort;
            var sortDirection = request.OrderBy;

            var validator = new SelectQueryParamsValidator<T>();
            validator.ValidateFields(fields);
            validator.ValidateFilter(filter);
            validator.ValidatePageOffset(pageLimit);
            validator.ValidatePageLimit(pageLimit);
            validator.ValidateSortField(sortField);
            validator.ValidateSortDirection(sortDirection);

            var status = validator.StatusInfo;
            if (status.Any())
                return BadRequest(new SelectResponse<T> { StatusInfo = status });

            var @params = new SelectQueryParams
            {
                Filter = filter,
                Fields = fields,
                PageOffset = pageOffset,
                PageLimit = pageLimit,
                SortField = sortField,
                SortDirection = sortDirection
            };

            // TODO move this into... something that wraps the UoW/R pattern and has the mapping for that type
            // TODO create a query provider for DTOs, but keep the QueryParams
            // Command.Set<T>().Select(@params);
            // Command.Set<T>().AsQueryable().Where(filter.ToFilterExpression()).SortBy(sortField, sortDirection).Fields(fields).ToPage(pageOffset, pageLimit);
            // the above is the EF pseudo code - queryable should be open, if the implementation supports it; otherwise, Select(@params) is the interface this controller will use
            // this project shouldn't know of or have access to IQueryable - its not needed in this context or for wider support - this just needs the service access

            return Ok(new SelectResponse<T> { Data = await Workspace.GetRepository<T>().Select(@params) });
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<SingleResponse<T>>> Single(SingleRequest request)
        {
            // TODO if (!ModelState.IsValid)

            var fields = request.Fields?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(field => field.Trim()).ToList().AsReadOnly();

            var validator = new SelectQueryParamsValidator<T>();
            validator.ValidateFields(fields);

            var status = validator.StatusInfo;
            if (status.Any())
                return BadRequest(new SelectResponse<T> { StatusInfo = status });

            var @params = new SingleQueryParams
            {
                Fields = fields,
                SourceId = request.SourceId
            };
            
            return Ok(new SingleResponse<T> { Data = await Workspace.GetRepository<T>().Single(@params) });
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<UpsertResponse<T>>> Upsert(UpsertRequest<T> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}