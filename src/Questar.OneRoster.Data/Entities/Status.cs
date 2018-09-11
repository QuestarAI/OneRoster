namespace Questar.OneRoster.Data.Entities
{
    using System;

    public enum Status
    {
        Active,
        ToBeDeleted,
        [Obsolete] Inactive = ToBeDeleted
    }
}