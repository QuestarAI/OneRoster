namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum OrgType
    {
        [EnumMember(Value = "department")]
        Department,

        [EnumMember(Value = "school")]
        School,

        [EnumMember(Value = "district")]
        District,

        [EnumMember(Value = "local")]
        Local,

        [EnumMember(Value = "state")]
        State,

        [EnumMember(Value = "national")]
        National
    }
}