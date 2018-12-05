namespace Questar.OneRoster.ApiFramework.Models.Responses
{
    using Newtonsoft.Json;
    using OneRoster.Models.Errors;

    public class Response<T>
    {
        [JsonProperty("statusInfoSet")]
        public StatusInfoList StatusInfo { get; set; }

        public T Data { get; set; }
    }
}