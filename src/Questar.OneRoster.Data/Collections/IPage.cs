namespace Questar.OneRoster.Data.Collections
{
    using System.Collections.Generic;

    public interface IPage<out T>
    {
        int Index { get; }

        int Size { get; }

        int Count { get; }

        IReadOnlyList<T> Items { get; }
    }
}