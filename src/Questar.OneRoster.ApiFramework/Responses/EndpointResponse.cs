namespace Questar.OneRoster.ApiFramework.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EndpointResponse
    {
        public IList<StatusInfo> StatusInfoSet { get; } = new List<StatusInfo>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object AcademicSession { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Category { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Class { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Course { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Enrollment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object LineItem { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Org { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Resource { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object User { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> AcademicSessions { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Categories { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Classes { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Courses { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Enrollments { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> LineItems { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Orgs { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Resources { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Users { get; set; }
    }
}