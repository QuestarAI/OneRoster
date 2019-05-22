namespace Questar.OneRoster.Models
{
    using System;
    using System.Runtime.Serialization;

    public enum StatusType
    {
        [EnumMember(Value = "active")]
        Active = 0,

        [EnumMember(Value = "tobedeleted")]
        ToBeDeleted = 1,

        [Obsolete("Inactive is deprecated. Use ToBeDeleted.")]
        [EnumMember(Value = "inactive")]
        Inactive = ToBeDeleted
    }
}