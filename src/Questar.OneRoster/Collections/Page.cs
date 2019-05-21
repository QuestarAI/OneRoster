namespace Questar.OneRoster.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Page<T> : IPage<T>
    {
        public Page(int count, IEnumerable<T> items)
        {
            if (count < 0) throw new ArgumentException($"'{nameof(count)}' must be greater than or equal to 0.");

            Count = count;
            Items = items.ToList().AsReadOnly();
        }

        public T this[int index] => Items[index];
        public int Count { get; }
        IEnumerable IPage.Items => Items;
        public IReadOnlyList<T> Items { get; }
    }
}