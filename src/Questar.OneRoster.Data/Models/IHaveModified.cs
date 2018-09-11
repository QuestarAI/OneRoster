namespace Questar.OneRoster.Data.Models
{
    using System;

    public interface IHaveModified
    {
        DateTimeOffset Modified { get; }
    }
}