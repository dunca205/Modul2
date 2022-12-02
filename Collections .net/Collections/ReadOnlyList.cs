using System.Collections;

namespace Collections
{
    public class ReadOnlyList<T> : IList<T>
    {
        const string Messsge = "The List is read - only";
        private readonly IList<T> list;

        public ReadOnlyList(IList<T> initialList)
        {
            list = initialList;
        }

        public int Count => list.Count;

        public bool IsReadOnly => true;

        public T this[int index]
        {
            get
            {
                OutOfRangeException(index);

                return list[index];
            }

            set => throw new NotSupportedException(Messsge);
        }

        public void Add(T item) => throw new NotSupportedException(Messsge);

        public void Clear() => throw new NotSupportedException(Messsge);

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item) => list.IndexOf(item);

        public void Insert(int index, T item) => throw new NotSupportedException(Messsge);

        public bool Remove(T item) => throw new NotSupportedException(Messsge);

        public void RemoveAt(int index) => throw new NotSupportedException(Messsge);

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        private void OutOfRangeException(int index)
        {
            if (IsValidIndex(index))
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: nameof(index), message: " index is not a valid index in the List");
        }

        private bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }
    }
}
