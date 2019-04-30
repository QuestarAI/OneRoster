namespace Questar.OneRoster.Client
{
    using Models.Errors;
    using Serialization;

    public class OneRosterSingle<T>
    {
        [OneRosterContract] public T Result { get; set; }

        public StatusInfoList StatusInfoSet { get; set; }
    }
}