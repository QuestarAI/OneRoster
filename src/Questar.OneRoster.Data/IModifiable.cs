namespace Questar.OneRoster.Data
{
    using System;

    public interface IModifiable
    {
        DateTime Modified { get; }
    }
}