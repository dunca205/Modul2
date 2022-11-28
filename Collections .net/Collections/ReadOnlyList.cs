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
            get
            {
                OutOfRangeException(index);

                return list[index];
            }

            set
            {
                NotSupportedException();
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            NotSupportedException();
        }

        public void Clear() => NotSupportedException();

        public bool Contains(T item) => IndexOf(item) != -1;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(paramName: nameof(array), "is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex), " is less than zero");
            }

            if (array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
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

        public int IndexOf(T item) => list.IndexOf(item);

        public void Insert(int index, T item)
        {
            NotSupportedException();
        }

        public bool Remove(T item)
        {
            NotSupportedException();
            return false;
        }

        public void RemoveAt(int index) => NotSupportedException();

        private void OutOfRangeException(int index)
        {
            if (IsValidIndex(index))
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: nameof(index), message: " index is not a valid index in the List");
        }

        private void NotSupportedException()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("The property is set and the List is read - only");
        }

        private bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }
    }
}
