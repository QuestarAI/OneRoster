namespace Questar.OneRoster.Model.Vocabulary
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