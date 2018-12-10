namespace Questar.OneRoster.Models
{
    using System;
    using Serialization;

    public enum StatusType
    {
        [SerializationToken("active")] Active = 0,

        [SerializationToken("tobedeleted")] ToBeDeleted = 1,

        [Obsolete("Inactive is deprecated. Use ToBeDeleted.")] [SerializationToken("inactive")]
        Inactive = ToBeDeleted
    }
}