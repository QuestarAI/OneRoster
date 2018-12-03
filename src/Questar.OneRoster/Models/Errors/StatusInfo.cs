namespace Questar.OneRoster.Models.Errors
{
    using Newtonsoft.Json; // TODO hmm... remove this dependency, if possible

    /// <summary>
    /// Represents an informational status about an API request/response.
    /// </summary>
    public class StatusInfo
    {
        [JsonProperty("imsx_codeMajor")]
        public CodeMajor CodeMajor { get; set; }

        [JsonProperty("imsx_codeMinor")]
        public CodeMinor CodeMinor { get; set; }

        [JsonProperty("imsx_severity")]
        public Severity Severity { get; set; }

        [JsonProperty("imsx_description")]
        public string Description { get; set; }

        [JsonProperty("imsx_messageRefIdentifier")]
        public string MessageRefIdentifier { get; set; }

        [JsonProperty("imsx_operationRefIdentifier")]
        public string OperationRefIdentifier { get; set; }
    }
}