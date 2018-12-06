namespace Questar.OneRoster.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ScopedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();

        private readonly ScopedDictionary<TKey, TValue> _parent;

        public ScopedDictionary(ScopedDictionary<TKey, TValue> previous = null) => _parent = previous;

        public void Add(TKey key, TValue value)
        {
            _items.Add(key, value);
        }

        public bool Remove(TKey key) => _items.Remove(key) || _parent.Remove(key);

        public bool TryGetValue(TKey key, out TValue value) => _items.TryGetValue(key, out value) || _parent?.TryGetValue(key, out value) == true;

        public TValue this[TKey key]
        {
            get => TryGetValue(key, out var value) ? value : throw new KeyNotFoundException("No key was found within the scope.");
            set => _items[key] = value;
        }

        public ICollection<TKey> Keys => _items.Keys.Concat(_parent?.Keys ?? Enumerable.Empty<TKey>()).ToList();

        public ICollection<TValue> Values => _items.Values.Concat(_parent?.Values ?? Enumerable.Empty<TValue>()).ToList();

        public bool ContainsKey(TKey key) => _items.ContainsKey(key) || _parent?.ContainsKey(key) == true;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }

            if (_parent == null) yield break;

            foreach (var item in _parent)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => _items.Contains(item) || _parent.Contains(item);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _parent?.CopyTo(array, arrayIndex += _parent.Count);
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => _items.Remove(item) || _parent.Remove(item);

        public int Count => _items.Count + _parent?.Count ?? 0;

        public bool IsReadOnly => false;
    }
}