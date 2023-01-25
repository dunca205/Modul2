using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;

       
       
        LinkedList<Entry<TKey, TValue>>[] elements;
        
        public Dictionary(int size)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);
            elements = new LinkedList < Entry<TKey, TValue>>[size];
        }

        public TValue this[TKey key] { get => this[key]; set => this[key] = value; }

        public ICollection<TKey> Keys { get; }
        public ICollection<TValue> Values { get; }
        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucket(key);
            var element = new Entry<TKey, TValue>(key, value);
            element.Index = Count;
          
            if (buckets[bucketIndex] == -1) 
            {
                elements[bucketIndex] = new LinkedList<Entry<TKey, TValue>>(); 
            }

            elements[bucketIndex].AddFirst(element);
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
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            //int bucketIndex = GetBucket(key);
            //return bucketIndex > 0 && bucketIndex < this.Count;
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int GetBucket(TKey key)
        {
            var absoluteValue = Math.Abs(key.GetHashCode());
            Math.DivRem(absoluteValue, buckets.Length, out int position);
            return position;
        }

        public IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}