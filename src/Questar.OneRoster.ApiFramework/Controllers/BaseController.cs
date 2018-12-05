namespace Questar.OneRoster.ApiFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Data;
    using Filtering;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;
    using OneRoster.Models.Errors;

    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : Base
    {
        protected static readonly HashSet<string> Properties = new HashSet<string>(typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(info => info.Name), StringComparer.OrdinalIgnoreCase);

        protected BaseController(IWorkspace workspace) => Workspace = workspace;

        protected IWorkspace Workspace { get; }

        [HttpGet]
        public virtual async Task<ActionResult<SelectResponse>> Select(SelectRequest request)
        {
            var statuses = new List<StatusInfo>();

            var fields = request.Fields?.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(field => field.Trim()).ToList();
            if (fields != null)
                if (fields.Any())
                    foreach (var property in fields.Where(field => !Properties.Contains(field)))
                        statuses.Add(new StatusInfo
                        {
                            CodeMajor = CodeMajor.Success,
                            CodeMinor = CodeMinor.InvalidSelectionField,
                            Severity = Severity.Warning,
                            Description = property
                        });
                else
                    statuses.Add(new StatusInfo
                    {
                        CodeMajor = CodeMajor.Failure,
                        CodeMinor = CodeMinor.InvalidBlankSelectionField,
                        Severity = Severity.Error
                    });

            var filter = request.Filter != null ? Filter.Parse(request.Filter) : null;
            if (fields != null)
                foreach (var property in filter.GetProperties().Select(property => property.Name).Where(field => !Properties.Contains(field)))
                    statuses.Add(new StatusInfo
                    {
                        CodeMajor = CodeMajor.Success,
                        CodeMinor = CodeMinor.InvalidFilterField,
                        Severity = Severity.Warning,
                        Description = property
                    });

            var sort = request.Sort;
            var direction = request.OrderBy;
            if (sort != null && !Properties.Contains(sort))
                statuses.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidSortField,
                    Severity = Severity.Warning,
                    Description = sort
                });

            var limit = request.Limit;
            if (limit < 0)
                statuses.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidLimitField,
                    Severity = Severity.Error,
                    Description = "Limit query parameter must be greater than 0."
                });

            var offset = request.Offset;
            if (offset < 0)
                statuses.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidOffsetField,
                    Severity = Severity.Error,
                    Description = "Offset query parameter must be greater than or equal to 0."
                });

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(new SelectResponse {StatusInfo = statuses});

            var data = await Workspace
                .GetRepository<T>()
                .Select()
                .Filter(filter)
                .Fields(fields)
                .Sort(sort, direction)
                .ToPageAsync(offset, limit);

            var count = data.Count;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkFactory = new OneRosterLinkHeaderFactory(HttpContext);
            var link = linkFactory.Create(offset, limit, count);
            if (!string.IsNullOrEmpty(link))
                HttpContext.Response.Headers.Add("Link", link);

            return Ok(new SelectResponse {Data = data}); // TODO data name
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<SingleResponse>> Single(SingleRequest request)
        {
            var statuses = new List<StatusInfo>();

            var fields = request.Fields?.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(field => field.Trim()).ToList();
            if (fields != null)
                if (fields.Any())
                    foreach (var property in fields.Where(field => !Properties.Contains(field)))
                        statuses.Add(new StatusInfo
                        {
                            CodeMajor = CodeMajor.Success,
                            CodeMinor = CodeMinor.InvalidSelectionField,
                            Severity = Severity.Warning,
                            Description = property
                        });
                else
                    statuses.Add(new StatusInfo
                    {
                        CodeMajor = CodeMajor.Failure,
                        CodeMinor = CodeMinor.InvalidBlankSelectionField,
                        Severity = Severity.Error
                    });

            if (statuses.Any(status => status.Severity == Severity.Error))
                return BadRequest(new SingleResponse {StatusInfo = statuses});

            var data = await Workspace
                .GetRepository<T>()
                .Single()
                .ToObjectAsync(request.SourcedId);

            return Ok(new SingleResponse {Data = data}); // TODO data name
        }

        // IUpsertable<T>
        //[HttpPut("{id}")]
        //public virtual async Task<ActionResult<UpsertResponse<T>>> Upsert(UpsertRequest<T> request) => throw new NotImplementedException();

        // IDeletable<T>
        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult<DeleteResponse<T>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}