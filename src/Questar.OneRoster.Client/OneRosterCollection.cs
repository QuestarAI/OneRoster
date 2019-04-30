namespace Questar.OneRoster.Client
{
    using System.Collections.Generic;
    using Models.Errors;
    using Serialization;

    public sealed class OneRosterCollection<T>
    {
        [OneRosterContract(Pluralize = true)] public List<T> Results { get; set; }

        public StatusInfoList StatusInfoSet { get; set; }
    }
}