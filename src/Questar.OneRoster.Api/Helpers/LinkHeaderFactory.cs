using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Questar.OneRoster.Api.Helpers
{
    public class LinkHeaderFactory
    {
        public LinkHeaderFactory(IHttpContextAccessor httpContextAccessor, IOptions<LinkHeaderFactoryOptions> options)
        {
            HttpContextAccessor = httpContextAccessor;
            Options = options;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public IOptions<LinkHeaderFactoryOptions> Options { get; }

        public string Create(int offset, int limit, int count)
        {
            var context = HttpContextAccessor.HttpContext;
            var options = Options.Value;

            var builder = new StringBuilder();
            var path = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";

            // Mutability of dictionary to be "abused" below for generating multiple query strings.
            // While the HTTP specs say query string keys should be case-sensitive, ASP.NET MVC is intentionally case-insensitive.
            // See https://github.com/aspnet/AspNetCore/issues/3450 for more.
            var query = context.Request.Query.ToDictionary(entry => entry.Key, entry => entry.Value, StringComparer.OrdinalIgnoreCase);
            if (limit == options.Limit)
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

            if (offset == options.Offset)
                return builder.ToString();

            if (includeNextAndLast)
                builder.Append(", ");

            query.Remove("offset");
            builder.AppendFormat(@"<{0}{1}>; rel=""first"", ", path, QueryString.Create(query));

            var prevOffset = Math.Max(options.Offset, offset - limit);
            if (prevOffset != options.Offset)
                query["offset"] = prevOffset.ToString();

            builder.AppendFormat(@"<{0}{1}>; rel=""prev""", path, QueryString.Create(query));

            return builder.ToString();
        }
    }
}