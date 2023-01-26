using System.Collections;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;
        List<Entry<TKey, TValue>>[] elements;
        //System.Collections.Generic.Dictionary<TKey, TValue> dictionary;

        public Dictionary(int size)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);
            elements = new List<Entry<TKey, TValue>>[size];
        }
        public TValue this[TKey key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    int bucket = GetBucket(key);
                    foreach (var element in elements[bucket])
                    {
                        if (element.Key.Equals(key))
                        {
                            return element.Value;
                        }
                    }
                }

                return default;
            }

            set
            {
                int bucket = GetBucket(key);
                foreach (var element in elements[bucket])
                {
                    if (element.Key.Equals(key))
                    {
                        element.Value = value;
                    }
                }
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                var listOfKeys = new List<TKey>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null)
                    {
                        foreach (var element in elements[i])
                        {
                            listOfKeys.Add(element.Key);
                        }
                    }
                }

                return listOfKeys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                var listOfValues = new List<TValue>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null)
                    {
                        foreach (var element in elements[i])
                        {
                            listOfValues.Add(element.Value);
                        }
                    }
                }

                return listOfValues;
            }
        }
        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucket(key);
            var element = new Entry<TKey, TValue>(key, value);
            element.Index = Count;

            if (buckets[bucketIndex] == -1)
            {
                elements[bucketIndex] = new List<Entry<TKey, TValue>>();
            }

            elements[bucketIndex].Insert(0, element);
            element.Next = buckets[bucketIndex];
            buckets[bucketIndex] = element.Index;
            Count++;
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Clear(buckets, 0, Count);
            foreach (var entry in elements)
            {
                entry.Clear();
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = this[key];
            return value != null;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int GetBucket(TKey key)
        {
            var absoluteValue = Math.Abs(key.GetHashCode());
            Math.DivRem(absoluteValue, buckets.Length, out int position);
            return position;
        }
        public Entry<TKey, TValue> GetElement(TKey key)
        {
            Entry<TKey, TValue> entry = null;
            var bucket = GetBucket(key);
            foreach(var element in elements[bucket])
            {
                if (element.Key.Equals(key))
                {
                    entry = element;
                }
            }
            return entry;
        }
    }
}