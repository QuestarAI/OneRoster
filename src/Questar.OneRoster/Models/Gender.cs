using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum Gender
    {
        [EnumMember(Value = "male")] Male,

        [EnumMember(Value = "female")] Female
    }
}