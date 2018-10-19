using Microsoft.AspNetCore.Mvc;

namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
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
            Action<EndpointResponse, IEnumerable<object>> beforeResponse)
            where T: class
        {
            var listTask = dbSet.ToListAsync(request);
            var countTask = dbSet.CountAsync(request);
            await Task.WhenAll(listTask, countTask);
            var count = countTask.Result;
            var response = new EndpointResponse();
            beforeResponse(response, listTask.Result);

            HttpContext.Response.Headers.Add("X-Total-Count", count.ToString());

            var linkHeaderValues = BuildLinkHeaderValues(request, count);
            if (!string.IsNullOrEmpty(linkHeaderValues))
            {
                HttpContext.Response.Headers.Add("Link", linkHeaderValues);
            }

            response.StatusInfoSet.Add(SuccessStatus);
            
            return Ok(response);
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