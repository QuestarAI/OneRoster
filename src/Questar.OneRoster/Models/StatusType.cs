namespace Questar.OneRoster.Models
{
    using System;
    using Serialization;

    public enum StatusType
    {
        [SerializationToken("tobedeleted")] ToBeDeleted = 0,

        [Obsolete("Please use ToBeDeleted.")]
        [SerializationToken("inactive")] Inactive = ToBeDeleted,

        [SerializationToken("active")] Active = 1
    }
}