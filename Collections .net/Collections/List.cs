using System.Collections;

namespace Collections
{
    public class List<T> : IList<T>
    {
        private T[] list;

        public List()
        {
            const int minimumCapacity = 4;
            list = new T[minimumCapacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get;
        }

        public virtual T this[int index]
        {
            get
            {
                OutOfRangeException(index);

                return list[index];
            }

            set
            {
                OutOfRangeException(index);

                list[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

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

            Array.Copy(list, 0, array, arrayIndex, Count);
        }

        public virtual void Add(T item)
        {
            ResizeArray();
            list[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(list, item, 0, Count);
        }

        public virtual void Insert(int index, T item)
        {
            OutOfRangeException(index);
            ResizeArray();
            ShiftRight(index);
            list[index] = item;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref list, 0);
            Count = 0;
        }

        public bool Remove(T item)
        {
            int countAfterElementIsRemoved = Count - 1;

            RemoveAt(IndexOf(item));

            return Count == countAfterElementIsRemoved;
        }

        public void RemoveAt(int index)
        {
            OutOfRangeException(index);
            ShiftLeft(index);
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        private void OutOfRangeException(int index)
        {
            if (IsValidIndex(index))
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: Convert.ToString(index), message: " index is not a valid index in the List");
        }

        private void ResizeArray()
        {
            if (list.Length > Count)
            {
                return;
            }

            const int doubleTheCapacity = 2;

            Array.Resize(ref list, Count * doubleTheCapacity);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                list[i] = list[i - 1];
            }
        }
    }
}
