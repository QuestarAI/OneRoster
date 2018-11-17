namespace Questar.OneRoster.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using RequestModels;
    using ResponseModels;

    public class CollectionEndpointContext<T>
    {
        private bool _hasParsedFields;
        private IList<string> _fieldsList;

        public CollectionEndpointContext(CollectionEndpointRequest<T> request)
            => Request = request;

        public CollectionEndpointRequest<T> Request { get; private set; }

        public EndpointResponse Response { get; private set; } = new EndpointResponse();

        public bool RequestSortIsValid { get; set; } = true;

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

        public void AddStatusInfo(StatusInfo statusInfo)
            => Response.StatusInfoSet.Add(statusInfo);

        public bool HasStatusInfo()
            => Response.StatusInfoSet.Any();

        public bool IsBadRequest()
            => Response.StatusInfoSet.Any(si => si.StatusCode == HttpStatusCode.BadRequest);
    }
}