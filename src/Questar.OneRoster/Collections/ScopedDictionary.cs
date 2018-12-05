namespace Questar.OneRoster.Collections
{
    using System.Collections.Generic;

    public class ScopedDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _scope = new Dictionary<TKey, TValue>();

        private readonly ScopedDictionary<TKey, TValue> _parent;

        public ScopedDictionary(ScopedDictionary<TKey, TValue> previous) => _parent = previous;

        public ScopedDictionary(ScopedDictionary<TKey, TValue> previous, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            : this(previous)
        {
            Add(pairs);
        }

        public void Add(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var p in pairs) Add(p.Key, p.Value);
        }

        public void Add(TKey key, TValue value)
            => _scope.Add(key, value);

        public bool TryGetValue(TKey key, out TValue value)
        {
            for (var scope = this; scope != null; scope = scope._parent)
                if (scope._scope.TryGetValue(key, out value))
                    return true;
            value = default;
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            for (var scope = this; scope != null; scope = scope._parent)
                if (scope._scope.ContainsKey(key))
                    return true;
            return false;
        }
    }
}