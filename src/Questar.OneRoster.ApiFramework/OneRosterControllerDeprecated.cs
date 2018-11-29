namespace Questar.OneRoster.ApiFramework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Api;
    using Attributes;
    using Common;
    using Extensions;
    using Filtering;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Reflection;
    using Requests;
    using Responses;

    [Produces("application/json")]
    public abstract class OneRosterControllerDeprecated : ControllerBase
    {
        private static readonly StatusInfo SuccessStatus = new StatusInfo
        {
            CodeMajor = CodeMajor.Success,
            CodeMinor = CodeMinor.FullSuccess,
            Severity = Severity.Status,
            Description = "OK"
        };

        protected async Task<IActionResult> GetCollectionAsync<T>(IQueryable<T> queryable, SelectRequest request)
            where T : class
        {
            var context = new CollectionEndpointContext<T>(request);
            var response = context.Response;

            Validate(context);

            if (context.IsBadRequest())
                return BadRequest(response);

            var list = queryable.ToListAsync(context);
            var count = await queryable.CountAsync(context);

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkHeaderValues = BuildLinkHeaderValues(request, count);
            if (!string.IsNullOrEmpty(linkHeaderValues))
                HttpContext.Response.Headers.Add("Link", linkHeaderValues);

            if (!context.HasStatusInfo())
                context.AddStatusInfo(SuccessStatus);

            var metadata = ControllerContext.ActionDescriptor.MethodInfo.GetCustomAttribute<OneRosterResultAttribute>();
            var source = new Dictionary<string, object>
            {
                { "StatusInfoSet", response.StatusInfo },
                { metadata.Name, await list }
            }; // TODO ToDynamicObject()
            var target = (ICollection<KeyValuePair<string, object>>)new ExpandoObject();
            foreach (var entry in source) target.Add(entry);
            return Ok(target);
        }

        private void Validate<T>(CollectionEndpointContext<T> context) where T : class
        {
            var propertyNames = Reflect<T>.PropertyNames;
            ValidateFilter(context, propertyNames);
            ValidateSort(context, propertyNames);
            ValidateOffset(context);
            ValidateLimit(context);
            ValidateFieldSelection(context, propertyNames);
        }

        private static void ValidateFilter<T>(CollectionEndpointContext<T> context, IEnumerable<string> propertyNames) where T : class
        {
            var filter = Filter.Parse(context.Request.Filter);
            var invalidNames = filter.GetProperties()
                .Select(property => property.Name)
                .Where(field => !propertyNames.Contains(field, StringComparer.OrdinalIgnoreCase));
            foreach (var name in invalidNames)
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidFilterField,
                    Severity = Severity.Warning,
                    //StatusCode = HttpStatusCode.BadRequest,
                    Description = name
                });
        }

        private void ValidateSort<T>(CollectionEndpointContext<T> context, IEnumerable<string> propertyNames) where T : class
        {
            var sortPropertyName = context.Request.Sort;
            if (string.IsNullOrWhiteSpace(sortPropertyName)) return;
            if (propertyNames.Contains(sortPropertyName)) return;

            context.RequestSortIsValid = false;
            context.AddStatusInfo(new StatusInfo
            {
                CodeMajor = CodeMajor.Success,
                CodeMinor = CodeMinor.InvalidSortField,
                Severity = Severity.Warning,
                //StatusCode = HttpStatusCode.OK,
                Description = sortPropertyName
            });
        }

        private void ValidateOffset<T>(CollectionEndpointContext<T> context) where T : class
        {
            if (context.Request.Offset >= 0) return;
            context.AddStatusInfo(new StatusInfo
            {
                CodeMajor = CodeMajor.Failure,
                CodeMinor = CodeMinor.InvalidOffsetField,
                Severity = Severity.Error,
                //StatusCode = HttpStatusCode.BadRequest,
                Description = "Offset query parameter must be greater than or equal to 0."
            });
        }

        private void ValidateLimit<T>(CollectionEndpointContext<T> context) where T : class
        {
            if (context.Request.Limit > 0) return;
            context.AddStatusInfo(new StatusInfo
            {
                CodeMajor = CodeMajor.Failure,
                CodeMinor = CodeMinor.InvalidLimitField,
                Severity = Severity.Error,
                //StatusCode = HttpStatusCode.BadRequest,
                Description = "Limit query parameter must be greater than 0."
            });
        }

        private void ValidateFieldSelection<T>(CollectionEndpointContext<T> context, IEnumerable<string> propertyNames) where T : class
        {
            var fields = context.Request.Fields;
            if (fields == null) return;
            if (string.IsNullOrWhiteSpace(fields)) // If IsWhiteSpace basically.
            {
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidBlankSelectionField,
                    Severity = Severity.Error
                });
                return;
            }

            var fieldsList = context.GetFieldsList();
            var invalidNames = fieldsList
                .Where(field => !propertyNames.Contains(field, StringComparer.OrdinalIgnoreCase));
            foreach (var name in invalidNames)
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidSelectionField,
                    Severity = Severity.Warning,
                    Description = name
                });
        }

        private string BuildLinkHeaderValues(SelectRequest request, int count)
        {
            var offset = request.Offset;
            var limit = request.Limit;

            var builder = new StringBuilder();
            var path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";

            // Mutability of dictionary to be "abused" below for generating multiple query strings.
            // While the HTTP specs say query string keys should be case-sensitive, ASP.NET MVC is intentionally case-insensitive.
            // See https://github.com/aspnet/AspNetCore/issues/3450 for more.
            var query = HttpContext.Request.Query.ToDictionary(entry => entry.Key, entry => entry.Value, StringComparer.OrdinalIgnoreCase);
            if (limit == Constants.DefaultLimit)
                query.Remove("limit");
            else
                query["limit"] = limit.ToString();

            var nextOffset = offset + limit;
            var includeNextAndLast = nextOffset <= count;
            if (includeNextAndLast)
            {
                query["offset"] = nextOffset.ToString();
                builder.AppendFormat(@"<{0}{1}>; rel=""next"", ", path, QueryString.Create(query));

                // Don't assume requester started at Offset = 0 and incremented by Limit each time.
                // Rely on int truncation to round down division result.
                var lastOffset = offset + (count - offset - 1) / limit * limit;
                query["offset"] = lastOffset.ToString();
                builder.AppendFormat(@"<{0}{1}>; rel=""last""", path, QueryString.Create(query));
            }

            if (offset == Constants.DefaultOffset) return builder.ToString();

            if (includeNextAndLast) builder.Append(", ");
            query.Remove("offset");
            builder.AppendFormat(@"<{0}{1}>; rel=""first"", ", path, QueryString.Create(query));

            var prevOffset = Math.Max(Constants.DefaultOffset, offset - limit);
            if (prevOffset != Constants.DefaultOffset) query["offset"] = prevOffset.ToString();

            builder.AppendFormat(@"<{0}{1}>; rel=""prev""", path, QueryString.Create(query));

            return builder.ToString();
        }


    }
}