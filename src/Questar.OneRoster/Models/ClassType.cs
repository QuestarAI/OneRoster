namespace Questar.OneRoster.Models
{
    using Serialization;

    public enum ClassType
    {
        [SerializationToken("homeroom")] Homeroom,

        [SerializationToken("scheduled")] Scheduled
    }
}