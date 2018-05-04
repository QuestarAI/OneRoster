namespace Questar.OneRoster.Model.Vocabulary
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