using Newtonsoft.Json;
using Questar.OneRoster.Serialization;

namespace Questar.OneRoster.Payloads
{
    public class Payload<T>
    {
        [OneRosterContract] public T Value { get; set; }

        [JsonProperty("statusInfoSet")] public StatusInfoList Statuses { get; set; }
    }
}