namespace Questar.OneRoster.Models.Errors
{
    using Newtonsoft.Json;

// TODO hmm... remove this dependency, if possible

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

        public static StatusInfo InvalidSortField(string property) => new StatusInfo { CodeMajor = CodeMajor.Success, CodeMinor = CodeMinor.InvalidSortField, Severity = Severity.Warning, Description = property };

        public static StatusInfo InvalidSelectionField(string property) => new StatusInfo { CodeMajor = CodeMajor.Success, CodeMinor = CodeMinor.InvalidSelectionField, Severity = Severity.Warning, Description = property };

        public static StatusInfo InvalidData(string property) => new StatusInfo { CodeMajor = CodeMajor.Success, CodeMinor = CodeMinor.InvalidData, Severity = Severity.Error, Description = property };

        public static StatusInfo InvalidFilterField(string property) => new StatusInfo { CodeMajor = CodeMajor.Success, CodeMinor = CodeMinor.InvalidFilterField, Severity = Severity.Error, Description = property };

        public static StatusInfo InvalidLimitField() => new StatusInfo { CodeMajor = CodeMajor.Failure, CodeMinor = CodeMinor.InvalidLimitField, Severity = Severity.Warning, Description = "Limit query parameter must be greater than 0." };

        public static StatusInfo InvalidOffsetField() => new StatusInfo { CodeMajor = CodeMajor.Failure, CodeMinor = CodeMinor.InvalidOffsetField, Severity = Severity.Warning, Description = "Offset query parameter must be greater than or equal to 0." };

        public static StatusInfo InvalidBlankSelectionField() => new StatusInfo { CodeMajor = CodeMajor.Failure, CodeMinor = CodeMinor.InvalidBlankSelectionField, Severity = Severity.Error };
    }
}