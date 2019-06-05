using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum ClassType
    {
        [EnumMember(Value = "homeroom")] Homeroom,

        [EnumMember(Value = "scheduled")] Scheduled
    }
}