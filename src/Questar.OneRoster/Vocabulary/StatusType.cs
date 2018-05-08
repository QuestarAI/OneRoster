namespace Questar.OneRoster.Vocabulary
{
    using Serialization;

    public enum StatusType
    {
        [SerializationToken("tobedeleted")]
        ToBeDeleted = 0,

        [SerializationToken("inactive")]
        Inactive = 0,

        [SerializationToken("active")]
        Active = 1,
    }
}