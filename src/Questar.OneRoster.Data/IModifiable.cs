using System;

namespace Questar.OneRoster.Data
{
    public interface IModifiable
    {
        DateTime Modified { get; }
    }
}