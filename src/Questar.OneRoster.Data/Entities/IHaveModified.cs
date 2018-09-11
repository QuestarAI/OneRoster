namespace Questar.OneRoster.Data.Entities
{
    using System;

    public interface IHaveModified
    {
        DateTimeOffset Modified { get; }
    }
}