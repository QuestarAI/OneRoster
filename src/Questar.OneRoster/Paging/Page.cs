namespace Questar.OneRoster.Paging
{
    using System.Collections.Generic;
    using System.Linq;

    public class Page<T> : IPage<T>
    {
        public Page(int index, int size, int count, IEnumerable<T> items)
        {
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