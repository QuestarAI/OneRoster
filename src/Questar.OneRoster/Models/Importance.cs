namespace Questar.OneRoster.Models
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