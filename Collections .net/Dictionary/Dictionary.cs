using System.Collections;
using System.Xml.Linq;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        List<Entry<TKey, TValue>>[] elements;
        private List<Entry<TKey, TValue>> removedElements;
        public int freeIndex;
        public Dictionary(int size)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);
            elements = new List<Entry<TKey, TValue>>[size];
            removedElements = new List<Entry<TKey, TValue>>();
        }
        public TValue this[TKey key]
        {
            get
            {
                return ContainsKey(key) ? Find(key).Value : default;
            }

            set
            {
                if (!ContainsKey(key))
                {
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
            CreateListForBucket(bucketIndex);

            Entry<TKey, TValue> element;
            if (removedElements.Count > 0)
            {
                element = RenewRemovedElements(key, value);
                removedElements.RemoveAt(0);
                UpdateFreeIndex();
            }
            else
            {
                element = new Entry<TKey, TValue>(key, value);
                element.Index = Count;
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

            int bucketIndex = GetBucket(key);
            var elementToRemove = Find(key);

            int indexOfElementToRemove = elements[bucketIndex].IndexOf(elementToRemove);
            if (indexOfElementToRemove > 0)
            {
                UpdatePrevElementPointer(bucketIndex, indexOfElementToRemove, elementToRemove.Next);
            }

            removedElements.Insert(0, elementToRemove);// punem elementul sters in capul listei de elemente sterse
            elements[bucketIndex].Remove(elementToRemove); //stergem elementul din lista
            UpdateFreeIndex();
            UpdadeBucket(bucketIndex);

            Count--;

            return Find(key) != null;
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
        public Entry<TKey, TValue> RenewRemovedElements(TKey key, TValue value)
        {
            removedElements[0].Key = key;
            removedElements[0].Value = value;
            return removedElements[0];
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
        private void UpdadeBucket(int bucketIndex)
        {
            if (elements[bucketIndex].Count == 0)
            {
                buckets[bucketIndex] = -1;
                return;
            }

            buckets[bucketIndex] = elements[bucketIndex][0].Index;
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
        private void UpdatePrevElementPointer(int bucket, int indexOfRemovedElement, int newPointer)
        {
          elements[bucket][indexOfRemovedElement - 1].Next = newPointer;
        }
    }
}