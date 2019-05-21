namespace Questar.OneRoster.Models
{
    using Errors;
    using Serialization;

    public class OneRosterSingle<T>
    {
        [OneRosterContract]
        public T Result { get; set; }

        public StatusInfoList StatusInfoSet { get; set; }
    }
}