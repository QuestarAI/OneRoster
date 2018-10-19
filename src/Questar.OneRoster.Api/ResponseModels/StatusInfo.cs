namespace Questar.OneRoster.Api.ResponseModels
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents an informational status about an API request/response.
    /// </summary>
    public class StatusInfo
    {
        [JsonProperty(PropertyName = "imsx_codeMajor")]
        public CodeMajor CodeMajor { get; set; }

        [JsonProperty(PropertyName = "imsx_codeMinor")]
        public CodeMinor CodeMinor { get; set; }

        [JsonProperty(PropertyName = "imsx_severity")]
        public Severity Severity { get; set; }

        [JsonProperty(PropertyName = "imsx_description")]
        public string Description { get; set; }
        
        [JsonProperty(PropertyName = "imsx_messageRefIdentifier")]
        public string MessageRefIdentifier { get; set; }

        [JsonProperty(PropertyName = "imsx_operationRefIdentifier")]
        public string OperationRefIdentifier { get; set; }
    }
}