namespace Questar.OneRoster.Vocabulary
{
    using Serialization;

    public enum Gender
    {
        [SerializationToken("male")]
        Male,

        [SerializationToken("female")]
        Female,
    }
}