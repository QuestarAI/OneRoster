namespace Questar.OneRoster.Models
{
    using Errors;
    using Serialization;

    public sealed class OneRosterCollection<T>
    {
        [OneRosterContract(Pluralize = true)]
        public T[] Results { get; set; }

        public StatusInfoList StatusInfoSet { get; set; }
    }
}