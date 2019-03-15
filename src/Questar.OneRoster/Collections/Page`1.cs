namespace Questar.OneRoster.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Page<T> : IPage<T>
    {
        public Page(int index, int size, int count, IEnumerable<T> items)
        {
            if (index < 0) throw new ArgumentException($"'{nameof(index)}' must be greater than or equal to 0.");
            if (size <= 0) throw new ArgumentException($"'{nameof(size)}' must be greater than 0.");
            if (count < 0) throw new ArgumentException($"'{nameof(count)}' must be greater than or equal to 0.");

            Index = index;
            Size = size;
            Count = count;
            Items = items.ToList();
        }

        public T this[int index] => Items[index];
        public int Index { get; }
        public int Size { get; }
        public int Count { get; }
        IEnumerable IPage.Items => Items;
        public IReadOnlyList<T> Items { get; }
    }
}