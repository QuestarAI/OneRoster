namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum Gender
    {
        [EnumMember(Value = "male")]
        Male,

        [EnumMember(Value = "female")]
        Female
    }
}