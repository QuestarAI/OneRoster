namespace Questar.OneRoster.Vocabulary
{
    using Serialization;

    public enum ClassType
    {
        [SerializationToken("homeroom")]
        Homeroom,

        [SerializationToken("scheduled")]
        Scheduled,
    }
}