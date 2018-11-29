namespace Questar.OneRoster.Data
{
    using System;

    public interface IModifiable
    {
        DateTimeOffset Modified { get; }
    }
}