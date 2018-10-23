namespace Questar.OneRoster.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using Query;
    using RequestModels;
    using ResponseModels;

    public class CollectionEndpointContext<T>
    {
        private Expression<Func<T, bool>> _predicate;
        private bool _hasParsedFilters;
        private bool _hasParsedFields;
        private IList<Filter> _parsedFilters;
        private IList<string> _fieldsList;

        public CollectionEndpointContext(CollectionEndpointRequest<T> request)
            => Request = request;

        public CollectionEndpointRequest<T> Request { get; private set; }

        public EndpointResponse Response { get; private set; } = new EndpointResponse();

        public bool RequestSortIsValid { get; set; } = true;

        public Expression<Func<T, bool>> GetPredicate()
        {
            if (_predicate != null) return _predicate;
            var filterPredicate = FilterExpressionBuilder<T>.FromFilters(GetParsedFilters());
            var urlPredicate = Request.GetUrlPredicate();
            return _predicate = urlPredicate.AndAlso(filterPredicate);
        }

        public IList<string> GetFieldsList()
        {
            if (_hasParsedFields)
            {
                return _fieldsList;
            }

            if (!string.IsNullOrWhiteSpace(Request.Fields))
            {
                _fieldsList = Request.Fields
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            }

            _hasParsedFields = true;
            return _fieldsList;
        }

        public IList<Filter> GetParsedFilters()
        {
            if (_hasParsedFilters)
            {
                return _parsedFilters;
            }

            if (!string.IsNullOrWhiteSpace(Request.Filter))
            {
                _parsedFilters = FilterParser.FromString(Request.Filter);
            }

            _hasParsedFilters = true;
            return _parsedFilters;
        }

        public void AddStatusInfo(StatusInfo statusInfo)
            => Response.StatusInfoSet.Add(statusInfo);

        public bool HasStatusInfo()
            => Response.StatusInfoSet.Any();

        public bool IsBadRequest()
            => Response.StatusInfoSet.Any(si => si.StatusCode == HttpStatusCode.BadRequest);
    }
}