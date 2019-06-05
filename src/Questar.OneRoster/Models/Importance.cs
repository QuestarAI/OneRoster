using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum Importance
    {
        [EnumMember(Value = "primary")] Primary,

        [EnumMember(Value = "secondary")] Secondary
    }
}