namespace Questar.OneRoster.Api.Models.Responses
{
    using Newtonsoft.Json;
    using OneRoster.Models.Errors;

    public class Response<T>
    {
        public Response(StatusInfoList statuses) => StatusInfo = statuses ?? new StatusInfoList();

        [JsonProperty("statusInfoSet")]
        public StatusInfoList StatusInfo { get; set; }

        public T Data { get; set; }
    }
}