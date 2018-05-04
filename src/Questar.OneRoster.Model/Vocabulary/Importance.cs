namespace Questar.OneRoster.Model.Vocabulary
{
    using Serialization;

    public enum Importance
    {
        [SerializationToken("primary")]
        Primary,

        [SerializationToken("secondary")]
        Secondary
    }
}