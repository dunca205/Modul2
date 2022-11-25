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
            get => list[index]; // se poate da un index invalid

            set
            {
                // cant be set
            }
        }

        public void Add(T item) => throw new NotImplementedException();

        public void Clear() => throw new NotImplementedException();

        public bool Contains(T item) => IndexOf(item) != -1;

        public void CopyTo(T[] array, int arrayIndex)
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
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
