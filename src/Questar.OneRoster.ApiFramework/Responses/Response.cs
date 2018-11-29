namespace Questar.OneRoster.ApiFramework.Responses
{
    using System.Collections.Generic;
    using Models.Errors;
    using Newtonsoft.Json;

    public class Response<T>
    {
        [JsonProperty("statusInfoSet")]
        public IList<StatusInfo> StatusInfo { get; set; }

        public T Data { get; set; }
    }
}