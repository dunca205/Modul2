using System.Collections;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;
        List<Entry<TKey, TValue>>[] elements;
        // System.Collections.Generic.Dictionary<TKey, TValue> dictionary;
        private List<Entry<TKey, TValue>> removedElements;
        public int freeIndex;
        public Dictionary(int size)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);
            elements = new List<Entry<TKey, TValue>>[size];
            removedElements = new List<Entry<TKey, TValue>>();
            freeIndex = -1;
        }
        public TValue this[TKey key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return Find(key).Value;
                }

                return default;
            }

            set
            {
                if (ContainsKey(key))
                {
                    Find(key).Value = value;
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

            CreateListForBucket(bucketIndex);

            SetIndex(element);

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
            return ContainsKey(item.Key) && Find(item.Key).Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var enumeratorKeys = Keys.GetEnumerator();
            var enumeratorValues = Values.GetEnumerator();

            while (enumeratorKeys.MoveNext() && enumeratorValues.MoveNext())
            {
                array[arrayIndex] = new KeyValuePair<TKey, TValue>(enumeratorKeys.Current, enumeratorValues.Current);
                arrayIndex++;
            }

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != -1)
                {
                    foreach (var element in elements[i])
                    {
                        yield return new KeyValuePair<TKey, TValue>(key: element.Key, value: element.Value);
                    }
                }
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null || !ContainsKey(key))
            {
                return false;
            }

            int bucket = GetBucket(key);
            var elementToRemove = Find(key);
            removedElements.Insert(0, elementToRemove);// punem elementul sters in capul listei de elemente sterse
            elements[bucket].Remove(elementToRemove);
            UpdateFreeIndex();
            Count--;

            return false;
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
            return GetEnumerator();
        }
        public int GetBucket(TKey key)
        {
            Math.DivRem(Math.Abs(key.GetHashCode()), buckets.Length, out int position);
            return position;
        }
        public Entry<TKey, TValue> Find(TKey key)
        {
            Entry<TKey, TValue> entry = null;
            var bucket = GetBucket(key);
            foreach (var element in elements[bucket])
            {
                if (element.Key.Equals(key))
                {
                    entry = element;
                }
            }
            return entry;
        }
        private void UpdateFreeIndex()
        {
            if (removedElements.Count == 0)
            {
                freeIndex = -1;
                return;
            }

            freeIndex = removedElements[0].Index;
        }
        private void CreateListForBucket(int bucketIndex)
        {
            if (buckets[bucketIndex] != -1)
            {
                return;
            }
            elements[bucketIndex] = new List<Entry<TKey, TValue>>();
        }
        private void SetIndex(Entry<TKey, TValue> element)
        {
            if (removedElements.Count > 0)
            {
                element.Index = removedElements[0].Index;
                removedElements.RemoveAt(0);
                UpdateFreeIndex();
                return;
            }

            element.Index = Count;
        }
    }
}