namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum Importance
    {
        [EnumMember(Value = "primary")]
        Primary,

        [EnumMember(Value = "secondary")]
        Secondary
    }
}