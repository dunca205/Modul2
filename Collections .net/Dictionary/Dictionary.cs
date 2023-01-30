using System.Collections;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private Entry<TKey, TValue>[] elements;
        public int freeIndex;
        public Dictionary(int size)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);
            elements = new Entry<TKey, TValue>[size];
            freeIndex = -1;
        }
        public TValue this[TKey key]
        {
            get
            {
                if (!Keys.Contains(key))
                {
                    return default;
                }

                return Find(key).Value;
            }

            set
            {
                if (!ContainsKey(key))
                {
                    Add(key, value);
                    return;
                }

                Find(key).Value = value;
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
                        listOfKeys.Add(elements[i].Key);
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
                for (int i = 0; i < Count; i++)
                {
                    if (elements[i] != null)
                    {
                        listOfValues.Add(elements[i].Value);
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
            Entry<TKey, TValue> element;

            if (freeIndex == -1) 
            {
                elements[Count] = new Entry<TKey, TValue>(key, value);
                elements[Count].Index = Count;
                elements[Count].Next = buckets[bucketIndex]; 
                buckets[bucketIndex] = Count;
                Count++;
                return;
            }

            int nextFreeIndex = elements[freeIndex].Next;
           
            elements[freeIndex].Key= key; 
            elements[freeIndex].Value= value; 
            elements[freeIndex].Next = buckets[bucketIndex]; 
            buckets[bucketIndex] = freeIndex;
            freeIndex = nextFreeIndex; 

            return;
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            Count = 0;
            Array.Clear(buckets, 0, Count);
            //foreach (var entry in elements)
            //{
            //    entry.Clear();
            //}
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key) && this[item.Key].Equals(item.Value);
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
            var keys = Keys.GetEnumerator();
            var values = Values.GetEnumerator();
            while (keys.MoveNext() && values.MoveNext())
            {
                yield return new KeyValuePair<TKey, TValue>(keys.Current, values.Current);
            }
        }
        public bool Remove(TKey key)
        {
            if (key == null || !ContainsKey(key))
            {
                return false;
            }

            var elementToRemove = Find(key);
            int bucketIndex = GetBucket(key);

            if (buckets[bucketIndex] == elementToRemove.Index)
            {
                buckets[bucketIndex] = elementToRemove.Next;
            }

            elementToRemove.Next = freeIndex;
            freeIndex = elementToRemove.Index;
            Count--;

            return true;
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
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
            foreach (var element in elements)
            {
                if (element.Key.Equals(key))
                {
                    return element;
                }
            }
            return default;
        }
     
    }
}