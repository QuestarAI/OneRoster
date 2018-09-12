namespace Questar.OneRoster.Data.Models
{
    using System;

    public enum Status
    {
        Active,
        ToBeDeleted,
        [Obsolete] Inactive = ToBeDeleted,
    }
}