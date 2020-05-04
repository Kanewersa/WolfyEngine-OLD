using System.Collections;
using System.Collections.Generic;

namespace WolfyECS
{
    public class BiDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        Dictionary<TKey, TValue> KeyMap { get; }
        Dictionary<TValue, TKey> ValueMap { get; }

        public BiDictionary(int capacity = 5)
        {
            KeyMap = new Dictionary<TKey, TValue>(capacity);
            ValueMap = new Dictionary<TValue, TKey>(capacity);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TValue this[TKey key]
        {
            get => KeyMap[key];
            set
            {
                KeyMap[key] = value;
                ValueMap[value] = key;
            }
        }

        public TKey this[TValue val]
        {
            get => ValueMap[val];
            set
            {
                KeyMap[value] = val;
                ValueMap[val] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key != null && value != null)
            {
                KeyMap.Add(key, value);
                ValueMap.Add(value, key);
            }
        }

        public bool Remove(TKey key)
        {
            var value = KeyMap[key];
            return value != null && ValueMap.ContainsKey(value)
                                 && ValueMap.Remove(value) && KeyMap.Remove(key);
        }

        public bool Remove(TValue value)
        {
            var key = ValueMap[value];
            return key != null && KeyMap.ContainsKey(key)
                               && KeyMap.Remove(key) && ValueMap.Remove(value);
        }

        public bool ContainsKey(TKey key)
        {
            return KeyMap.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return ValueMap.ContainsKey(value);
        }
    }
}
