namespace Questar.OneRoster.ApiFramework.Models.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OneRoster.Models.Errors;

    public class Response<T>
    {
        [JsonProperty("statusInfoSet")]
        public IList<StatusInfo> StatusInfo { get; set; }

        public T Data { get; set; }
    }
}