using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum OrgType
    {
        [EnumMember(Value = "department")] Department,

        [EnumMember(Value = "school")] School,

        [EnumMember(Value = "district")] District,

        [EnumMember(Value = "local")] Local,

        [EnumMember(Value = "state")] State,

        [EnumMember(Value = "national")] National
    }
}