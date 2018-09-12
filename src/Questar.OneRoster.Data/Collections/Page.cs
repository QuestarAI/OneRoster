namespace Questar.OneRoster.Data.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Page<T> : IPage<T>
    {
        public Page(int index, int size, int count, IEnumerable<T> items)
        {
            Debug.Assert(index >= 0, $"{nameof(index)} must be greater than or equal to 0.");
            Debug.Assert(size > 0, $"{nameof(size)} must be greater than 0.");
            Debug.Assert(count >= 0, $"{nameof(count)} must be greater than or equal to 0.");

            Index = index;
            Size = size;
            Count = count;
            Items = items.ToList();
        }

        public T this[int index] => Items[index];
        public int Index { get; }
        public int Size { get; }
        public int Count { get; }
        public IReadOnlyList<T> Items { get; }
    }
}