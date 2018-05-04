namespace Questar.OneRoster.Model.Vocabulary
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