namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum ClassType
    {
        [EnumMember(Value = "homeroom")]
        Homeroom,

        [EnumMember(Value = "scheduled")]
        Scheduled
    }
}