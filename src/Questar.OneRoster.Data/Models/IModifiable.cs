namespace Questar.OneRoster.Data.Models
{
    using System;

    public interface IModifiable
    {
        DateTimeOffset Modified { get; }
    }
}