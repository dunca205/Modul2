using System.Collections;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private Entry<TKey, TValue>[] elements;
        private int freeIndex;

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
                ArgumentNullExceptions(key);
                KeyNotFoundException(key);

                return elements[FindIndex(key)].Value;
            }

            set
            {
                ArgumentNullExceptions(key);
                var elementIndex = FindIndex(key);
                if (elementIndex == -1)
                {
                    Add(key, value);
                    return;
                }

                elements[elementIndex].Value = value;
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                var listOfKeys = new List<TKey>();
                var enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    listOfKeys.Add(enumerator.Current.Key);
                }

                return listOfKeys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                var listOfValues = new List<TValue>();
                var enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    listOfValues.Add(enumerator.Current.Value);
                }

                return listOfValues;
            }
        }
        public int Count { get; set; }
        public bool IsReadOnly { get; }
        public void Add(TKey key, TValue value)
        {
            InvalidOperationException();
            ArgumentNullExceptions(key);
            ArgumentException(key);

            int bucketIndex = GetBucket(key);
            int elementIndex = GetIndexForNewElement();

            elements[elementIndex].Key = key;
            elements[elementIndex].Value = value;
            elements[elementIndex].Next = buckets[bucketIndex];
            buckets[bucketIndex] = elementIndex;
            Count++;

            return;
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            Array.Fill(buckets, -1);
            Count = 0;
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int index = FindIndex(item.Key);
            return index != -1 && elements[index].Value.Equals(item.Value);
        }
        public bool ContainsKey(TKey key)
        {
            ArgumentNullExceptions(key);
            return FindIndex(key) != -1;
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ArgumentNullExceptions(array);
            ArgumentOutOfRangeException(arrayIndex);
            ArgumentException(array, arrayIndex);

            var getEnumerator = GetEnumerator();
            while (getEnumerator.MoveNext())
            {
                array[arrayIndex] = getEnumerator.Current;
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
            }

        }
        public bool Remove(TKey key)
        {
            ArgumentNullExceptions(key);
            KeyNotFoundException(key);

            var elementToRemove = FindIndex(key);
            int bucketIndex = GetBucket(key);

            if (buckets[bucketIndex] == elementToRemove)
            {
                buckets[bucketIndex] = elements[elementToRemove].Next;
            }

            for (int i = buckets[bucketIndex]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Next == elementToRemove)
                {
                    elements[i].Next = elements[elementToRemove].Next;
                    break;
                }
            }
            elements[elementToRemove].Next = freeIndex;
            freeIndex = elementToRemove;
            Count--;

            return ContainsKey(key);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            ArgumentNullExceptions(key);

            int index = FindIndex(key);
            if (index == -1)
            {
                value = default;
                return false;
            }

            value = elements[index].Value;
            return true;

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private int GetBucket(TKey key)
        {
            Math.DivRem(Math.Abs(key.GetHashCode()), buckets.Length, out int position);
            return position;
        }
        private int GetIndexForNewElement()
        {
            if (freeIndex == -1)
            {
                elements[Count] = new Entry<TKey, TValue>(default, default);
                return Count;
            }

            int tempFreeIndex = freeIndex;
            freeIndex = elements[freeIndex].Next;
            return tempFreeIndex;

        }
        private int FindIndex(TKey key)
        {
            int bucketIndex = GetBucket(key);
            for (int i = buckets[bucketIndex]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }
        private void InvalidOperationException()
        {
            if (Count < elements.Length)
            {
                return;
            }

            throw new InvalidOperationException("The dictionary cannot hold any more items.");
        }
        private void KeyNotFoundException(TKey key)
        {
            if (ContainsKey(key))
            {
                return;
            }
            throw new KeyNotFoundException();
        }
        private void ArgumentException(TKey key)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            throw new ArgumentException("An element with the same key already exists in the Dictionary.");
        }
        private void ArgumentException(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (Count <= array.Length - arrayIndex)
            {
                return;
            }

            throw new ArgumentException("The number of elements in the source ICollection is greater than the available space from index to the end of the destination array.}");
        }
        private static void ArgumentNullExceptions(object obj)
        {
            if (obj != null)
            {
                return;
            }
            throw new ArgumentNullException(nameof(obj));
        }
        private static void ArgumentOutOfRangeException(int arrayIndex)
        {
            if (arrayIndex >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex), "is less than zero.");
        }

    }
}