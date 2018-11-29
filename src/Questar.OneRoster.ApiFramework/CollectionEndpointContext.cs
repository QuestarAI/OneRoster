namespace Questar.OneRoster.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using ApiFramework.Requests;
    using ApiFramework.Responses;
    using Models.Errors;


    public class CollectionEndpointContext<T>
    {
        private bool _hasParsedFields;
        private IList<string> _fieldsList;

        public CollectionEndpointContext(SelectRequest request)
            => Request = request;

        public SelectRequest Request { get; private set; }

        public Response<T> Response { get; private set; } = new Response<T>();

        public bool RequestSortIsValid { get; set; } = true;

        public IList<string> GetFieldsList()
        {
            if (_hasParsedFields)
                return _fieldsList;

            if (!string.IsNullOrWhiteSpace(Request.Fields))
            {
                _fieldsList = Request.Fields
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(field => field.Trim())
                    .ToList();
            }

            _hasParsedFields = true;

            return _fieldsList;
        }

        public void AddStatusInfo(StatusInfo statusInfo)
            => Response.StatusInfo.Add(statusInfo);

        public bool HasStatusInfo()
            => Response.StatusInfo.Any();

        public bool IsBadRequest()
            => throw new NotImplementedException();
            //=> Response.StatusInfo.Any(si => si.StatusCode == HttpStatusCode.BadRequest);
    }
}