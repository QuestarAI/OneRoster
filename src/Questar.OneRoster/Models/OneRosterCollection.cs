namespace Questar.OneRoster.Models
{
    using System.Collections.Generic;
    using Errors;
    using Serialization;

    public sealed class OneRosterCollection<T>
    {
        [OneRosterContract(Pluralize = true)]
        public List<T> Results { get; set; }

        public StatusInfoList StatusInfoSet { get; set; }
    }
}