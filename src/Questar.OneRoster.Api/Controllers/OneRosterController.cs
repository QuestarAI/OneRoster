using Microsoft.AspNetCore.Mvc;

namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Query;
    using RequestModels;
    using ResponseModels;

    public abstract class OneRosterController : Controller
    {
        private static readonly StatusInfo SuccessStatus = new StatusInfo
        {
            CodeMajor = CodeMajor.Success,
            CodeMinor = CodeMinor.FullSuccess,
            Severity = Severity.Status,
            Description = "OK"
        };

        protected async Task<IActionResult> GetCollectionAsync<T>(
            DbSet<T> dbSet,
            CollectionEndpointRequest<T> request,
            Action<EndpointResponse, IEnumerable<object>> beforeOkResponse)
            where T: class
        {
            var context = new CollectionEndpointContext<T>(request);
            var response = context.Response;

            Validate(context);

            if (context.IsBadRequest())
            {
                return BadRequest(response);
            }

            var listTask = dbSet.ToListAsync(context);
            var countTask = dbSet.CountAsync(context);
            await Task.WhenAll(listTask, countTask);
            var count = countTask.Result;

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkHeaderValues = BuildLinkHeaderValues(request, count);
            if (!string.IsNullOrEmpty(linkHeaderValues))
            {
                HttpContext.Response.Headers.Add("Link", linkHeaderValues);
            }

            if (!context.HasStatusInfo())
            {
                context.AddStatusInfo(SuccessStatus);
            }

            beforeOkResponse(response, listTask.Result);

            return Ok(response);
        }

        private void Validate<T>(CollectionEndpointContext<T> context) where T : class
        {
            var propertyNames = ReflectionCache<T>.PropertyNames;
            ValidateFilter(context, propertyNames);
            ValidateSort(context, propertyNames);
            ValidateOffset(context);
            ValidateLimit(context);
            ValidateFieldSelection(context, propertyNames);
        }

        private static void ValidateFilter<T>(CollectionEndpointContext<T> context, IEnumerable<string> propertyNames) where T : class
        {
            var parsedFilters = context.GetParsedFilters();
            if (parsedFilters == null) return;
            var invalidNames = parsedFilters
                .Select(filter => filter.FieldName)
                .Where(field => !propertyNames.Contains(field, StringComparer.OrdinalIgnoreCase));
            foreach (var name in invalidNames)
            {
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidFilterField,
                    Severity = Severity.Warning,
                    StatusCode = HttpStatusCode.BadRequest,
                    Description = name,
                });
            }
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
                StatusCode = HttpStatusCode.OK,
                Description = sortPropertyName,
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
                StatusCode = HttpStatusCode.BadRequest,
                Description = "Offset query parameter must be greater than or equal to 0.",
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
                StatusCode = HttpStatusCode.BadRequest,
                Description = "Limit query parameter must be greater than 0.",
            });
        }

        private void ValidateFieldSelection<T>(CollectionEndpointContext<T> context, IList<string> propertyNames) where T : class
        {
            var fields = context.Request.Fields;
            if (fields == null) return;
            if (string.IsNullOrWhiteSpace(fields)) // If IsWhiteSpace basically.
            {
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidBlankSelectionField,
                    Severity = Severity.Error,
                    StatusCode = HttpStatusCode.BadRequest,
                });
                return;
            }

            var fieldsList = context.GetFieldsList();
            var invalidNames = fieldsList
                .Where(field => !propertyNames.Contains(field, StringComparer.OrdinalIgnoreCase));
            foreach (var name in invalidNames)
            {
                context.AddStatusInfo(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidSelectionField,
                    Severity = Severity.Warning,
                    StatusCode = HttpStatusCode.OK,
                    Description = name,
                });
            }
        }

        private string BuildLinkHeaderValues<T>(CollectionEndpointRequest<T> request, int count) where T : class
        {
            var offset = request.Offset;
            var limit = request.Limit;

            var builder = new StringBuilder();
            var path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";

            // Mutability of dictionary to be "abused" below for generating multiple query strings.
            // While the HTTP specs say query string keys should be case-sensitive, ASP.NET MVC is intentionally case-insensitive.
            // See https://github.com/aspnet/AspNetCore/issues/3450 for more.
            var query = new Dictionary<string, StringValues>(HttpContext.Request.Query, StringComparer.OrdinalIgnoreCase);
            if (limit == Constants.DefaultLimit)
            {
                query.Remove("limit");
            }
            else
            {
                query["limit"] = limit.ToString();
            }

            var nextOffset = offset + limit;
            var includeNextAndLast = nextOffset <= count;
            if (includeNextAndLast)
            {
                query["offset"] = nextOffset.ToString();
                builder.AppendFormat(@"<{0}{1}>; rel=""next"", ", path, QueryString.Create(query));

                // Don't assume requester started at Offset = 0 and incremented by Limit each time.
                // Rely on int truncation to round down division result.
                var lastOffset = offset + ((count - offset - 1) / limit) * limit;
                query["offset"] = lastOffset.ToString();
                builder.AppendFormat(@"<{0}{1}>; rel=""last""", path, QueryString.Create(query));
            }

            if (offset == Constants.DefaultOffset) return builder.ToString();

            if (includeNextAndLast) builder.Append(", ");
            query.Remove("offset");
            builder.AppendFormat(@"<{0}{1}>; rel=""first"", ", path, QueryString.Create(query));

            var prevOffset = Math.Max(Constants.DefaultOffset, offset - limit);
            if (prevOffset != Constants.DefaultOffset)
            {
                query["offset"] = prevOffset.ToString();
            }
            
            builder.AppendFormat(@"<{0}{1}>; rel=""prev""", path, QueryString.Create(query));

            return builder.ToString();
        }
    }
}