namespace Questar.OneRoster.Payloads
{
    using Newtonsoft.Json;
    using Serialization;

    public class Payload<T>
    {
        [OneRosterContract]
        public T Value { get; set; }

        [JsonProperty("statusInfoSet")]
        public StatusInfoList Statuses { get; set; }
    }
}