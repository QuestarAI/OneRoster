using System.Collections.Generic;

namespace Questar.OneRoster.Collections
{
    public interface IPage<out T> : IPage
    {
        new IReadOnlyList<T> Items { get; }
    }
}