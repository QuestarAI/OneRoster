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
    using Reflection;
    using Requests;
    using Responses;

    [Produces("application/json")]
    public abstract class OneRosterController<T> : ControllerBase where T : Base
    {
        protected OneRosterController(IWorkspace workspace) => Workspace = workspace;

        protected IWorkspace Workspace { get; }

        [HttpPost]
        public virtual async Task<ActionResult<CreateResponse<T>>> Create(CreateRequest<T> request) => throw new NotImplementedException();

        [HttpGet]
        public virtual async Task<ActionResult<SelectResponse<T>>> Select(SelectRequest request)
        {
            var status = new List<StatusInfo>();
            var properties = new HashSet<string>(Reflect<T>.PropertyNames, StringComparer.OrdinalIgnoreCase);

            var filter = request.Filter != null
                ? Filter.Parse(request.Filter)
                : null;

            foreach (var property in filter.GetProperties().Select(property => property.Name).Where(field => !properties.Contains(field)))
                status.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidFilterField,
                    Severity = Severity.Warning,
                    Description = property
                });

            var fields = request.Fields?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(field => field.Trim()).ToList().AsReadOnly();
            if (fields != null)
            {
                if (fields.Any())
                {
                    foreach (var property in fields.Where(field => !properties.Contains(field)))
                        status.Add(new StatusInfo
                        {
                            CodeMajor = CodeMajor.Success,
                            CodeMinor = CodeMinor.InvalidSelectionField,
                            Severity = Severity.Warning,
                            Description = property
                        });
                }
                else
                {
                    status.Add(new StatusInfo
                    {
                        CodeMajor = CodeMajor.Failure,
                        CodeMinor = CodeMinor.InvalidBlankSelectionField,
                        Severity = Severity.Error
                    });
                }
            }

            var pageOffset = request.Offset;
            if (pageOffset < 0)
                status.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidOffsetField,
                    Severity = Severity.Error,
                    Description = "Offset query parameter must be greater than or equal to 0."
                });

            var pageLimit = request.Limit;
            if (pageLimit < 0)
                status.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidLimitField,
                    Severity = Severity.Error,
                    Description = "Limit query parameter must be greater than 0."
                });

            var sortField = request.Sort;
            if (sortField != null && !properties.Contains(sortField))
            {
                status.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidSortField,
                    Severity = Severity.Warning,
                    Description = sortField
                });
            }

            var sortDirection = request.OrderBy;

            var @params = new SelectQueryParams
            {
                Filter = filter,
                Fields = fields,
                PageOffset = pageOffset,
                PageLimit = pageLimit,
                SortField = sortField,
                SortDirection = sortDirection
            };

            // TODO move the above to       QueryParamsValidator
            // TODO move the above to SelectQueryParamsValidator : QueryParamsValidator
            // TODO move the other to SingleQueryParamsValidator : QueryParamsValidator

            if (status.Any())
            {
                return BadRequest(new SelectResponse<T> { StatusInfo = status });
            }

            // TODO move this into... something that wraps the UoW/R pattern and has the mapping for that type
            // TODO create a query provider for DTOs, but keep the QueryParams
            // Command.Set<T>().Select(@params);
            // Command.Set<T>().AsQueryable().Where(filter.ToFilterExpression()).SortBy(sortField, sortDirection).Fields(fields).ToPage(pageOffset, pageLimit);
            // the above is the EF pseudo code - queryable should be open, if the implementation supports it; otherwise, Select(@params) is the interface this controller will use
            // this project shouldn't know of or have access to IQueryable - its not needed in this context or for wider support - this just needs the service access

            var data = await Workspace.GetRepository<T>().Select(@params);

            return Ok(new SelectResponse<T> { Data = data });
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<SingleResponse<T>>> Single(SingleRequest request) => throw new NotImplementedException();

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<UpdateResponse<T>>> Update(UpdateRequest<T> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}