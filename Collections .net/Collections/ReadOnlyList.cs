using System;
using System.Collections;

namespace Collections
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly List<T> list;

        public ReadOnlyList(List<T> initialList)
        {
            list = initialList;
        }

        public int Count { get => list.Count; }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public T this[int index]
        {
            get => list[index];

            set
            {
               // cant be set
            }
        }

        public void Add(T item) => throw new NotImplementedException(); // metoda in ICollection

        public void Clear() => throw new NotImplementedException(); // metoda in ICollection

        public bool Contains(T item) => IndexOf(item) != -1; // metoda in ICollection

        public void CopyTo(T[] array, int arrayIndex) // metoda in ICollection
        {
            bool canBeCopied = this.Count <= (array.Length - arrayIndex);
            if (!IsValidIndex(arrayIndex) || !canBeCopied)
            {
                return;
            }

            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

        public int IndexOf(T item) => list.IndexOf(item); // metoda in IList

        public void Insert(int index, T item) => throw new NotImplementedException(); // metoda in IList

        public bool Remove(T item) => throw new NotImplementedException(); // metoda in ICollection

        public void RemoveAt(int index) => throw new NotImplementedException(); // metoda in IList

        private bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }
    }
}
