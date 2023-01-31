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
                var element = Find(key);
                if (element == null)
                {
                    Add(key, value);
                    return;
                }

                element.Value = value;
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                var listOfKeys = new List<TKey>();
                //var enumerator = GetEnumerator();
                //while (enumerator.MoveNext()) 
                //{
                //    listOfKeys.Add(enumerator.Current.Key);
                //}
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && freeIndex != elements[i].Index)
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
                for (int i = 0; i < elements.Length; i++)
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

            elements[freeIndex].Key = key;
            elements[freeIndex].Value = value;
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
            for (int i = 0; i < buckets.Length; i++)
            {

                for (int elementBucket = buckets[i]; elementBucket != -1; elementBucket = elements[elementBucket].Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(key: elements[elementBucket].Key, value: elements[elementBucket].Value);
                }

                //var elementBucket = elements[buckets[i]]; // elementul din bucketul i 

                //for (int j = freeIndex; j != -1; j = elements[freeIndex].Next) // comparam elementele din bucket cu fiecare element free 
                //{
                //    if (elementBucket.Index != elements[j].Index) // verificam daca elementBucket  este pe lista de elemente sterse 
                //    {
                //        yield return new KeyValuePair<TKey, TValue>(key: elementBucket.Key, value: elementBucket.Value);
                //        if (elementBucket.Next == -1)
                //        {
                //            break;// break daca elementBucket  este ultimul din bucket
                //        }
                //        elementBucket = elements[elementBucket.Next]; // inaintam cu un el
                //    }
                //}

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

            for (int i = buckets[bucketIndex]; i != -1; i = elements[i].Next) // parcurgem bucketu; 
            {
                if (elements[i].Next == elementToRemove.Index)
                {
                    elements[i].Next = elementToRemove.Next;
                    break;
                }
            }
            elements[elementToRemove.Index].Next = freeIndex;
            freeIndex = elementToRemove.Index;
            Count--;

            return !Keys.Contains(key);
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