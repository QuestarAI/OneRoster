namespace Questar.OneRoster.Collections
{
    using System.Collections.Generic;

    public interface IPage<out T> : IPage
    {
        new IReadOnlyList<T> Items { get; }
    }
}