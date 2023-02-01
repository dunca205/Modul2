using System;
using System.Collections;
using System.Reflection;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private Entry<TKey, TValue>[] elements;
        private int freeIndex;
        System.Collections.Generic.Dictionary<TKey, TValue> dictionay;


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

                return Find(key).Value;
            }

            set
            {
                ArgumentNullExceptions(key);
                var element = Find(key);
                if (element == default)
                {
                    Add(key, value);
                    return;
                }

                elements[element.Index].Value = value;
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
            int bucketIndex = GetBucket(key);

            ArgumentNullExceptions(key);
            ArgumentException(key);

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
            Array.Fill(buckets, -1);
            Count = 0;
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key) && this[item.Key].Equals(item.Value);
        }
        public bool ContainsKey(TKey key)
        {
            ArgumentNullExceptions(key);
            return Keys.Contains(key);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ArgumentNullExceptions(array);
            ArgumentOutOfRangeException(arrayIndex);
            ArgumentException(array, arrayIndex);

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
            }

        }
        public bool Remove(TKey key)
        {
            ArgumentNullExceptions(key);
            KeyNotFoundException(key);
            var elementToRemove = Find(key);
            int bucketIndex = GetBucket(key);

            if (buckets[bucketIndex] == elementToRemove.Index)
            {
                buckets[bucketIndex] = elementToRemove.Next;
            }

            for (int i = buckets[bucketIndex]; i != -1; i = elements[i].Next) // parcurgem bucketu ca sa actualizam elementul care pointa spre cel ce trb sters
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

            return ContainsKey(key);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            ArgumentNullExceptions(key);

            if (ContainsKey(key))
            {
                value = this[key];
                return true;
            }

            value = default;
            return false;

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
                if (element?.Key.Equals(key) == true)
                {
                    return element;
                }
            }

            return default;
        }
        private static void ArgumentNullExceptions(object obj)
        {
            if (obj != null)
            {
                return;
            }
            throw new ArgumentNullException(nameof(obj));
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
        private static void ArgumentOutOfRangeException(int arrayIndex)
        {
            if (arrayIndex >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex), "is less than zero.");
        }
        private  void ArgumentException(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array.Rank > 1)
            {
                throw new ArgumentException(" is multidimensional", nameof(array));
            }

            if (Count <= array.Length - arrayIndex)
            {
                return;
            }

            throw new ArgumentException("The number of elements in the source ICollection is greater than the available space from index to the end of the destination array.}");
        }

    }
}