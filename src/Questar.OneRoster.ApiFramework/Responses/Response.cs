namespace Questar.OneRoster.ApiFramework.Responses
{
    using System.Collections.Generic;
    using Collections;
    using Newtonsoft.Json;

    public class Response<T>
    {
        [JsonProperty("statusInfoSet")]
        public IList<StatusInfo> StatusInfo { get; set; }

        public T Data { get; set; }
    }

    public class CreateResponse<T> : Response<T>
    {
    }

    public class SelectResponse<T> : Response<Page<T>>
    {
    }

    public class SingleResponse<T> : Response<T>
    {
    }

    public class UpdateResponse<T> : Response<T>
    {
    }

    public class DeleteResponse<T> : Response<T>
    {
    }
}