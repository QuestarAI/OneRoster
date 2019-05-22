namespace Questar.OneRoster.Test.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ScopedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();

        private readonly ScopedDictionary<TKey, TValue> _parent;

        public ScopedDictionary(ScopedDictionary<TKey, TValue> previous = null) =>
            _parent = previous;

        public TValue this[TKey key]
        {
            get => TryGetValue(key, out var value) ? value : throw new KeyNotFoundException("No key was found within the scope.");
            set => _items[key] = value;
        }

        public int Count => _items.Count + _parent?.Count ?? 0;

        public void Add(TKey key, TValue value) =>
            _items.Add(key, value);

        public bool Remove(TKey key) =>
            _items.Remove(key) || _parent.Remove(key);

        public bool TryGetValue(TKey key, out TValue value) =>
            _items.TryGetValue(key, out value) || _parent?.TryGetValue(key, out value) == true;

        public ICollection<TKey> Keys => _items.Keys.Concat(_parent?.Keys ?? Enumerable.Empty<TKey>()).ToList();

        public ICollection<TValue> Values => _items.Values.Concat(_parent?.Values ?? Enumerable.Empty<TValue>()).ToList();

        public void Clear() =>
            _items.Clear();

        public bool ContainsKey(TKey key) =>
            _items.ContainsKey(key) || _parent?.ContainsKey(key) == true;

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            foreach (var item in _items)
                yield return item;
            if (_parent == null)
                yield break;
            foreach (var item in _parent)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable<KeyValuePair<TKey, TValue>>) this).GetEnumerator();

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) =>
            _items.Add(item);

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) =>
            _items.Contains(item) || _parent.Contains(item);

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>) _parent)?.CopyTo(array, arrayIndex += _parent.Count);
            _items.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) =>
            _items.Remove(item) || ((ICollection<KeyValuePair<TKey, TValue>>) _parent).Remove(item);
    }
}