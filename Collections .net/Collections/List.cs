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
            get
            {
                return false; // colectia nu este ReadOnly 
            }
        }

        public virtual T this[int index]
        {
            get => list[index];

            set
            {
                if (!IsValidIndex(index) || IsReadOnly)
                {
                    return;
                }

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
            bool canBeCopied = this.Count <= (array.Length - arrayIndex);
            if (!IsValidIndex(arrayIndex) || !canBeCopied)
            {
                return;
            }

            Array.Copy(list, 0, array, arrayIndex, Count);
        }

        public virtual void Add(T item)
        {
            if (IsReadOnly) // A collection that is read-only does not allow the addition of elements after the collection is created.
            {
                return;
            }

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
            if (!IsValidIndex(index) || IsReadOnly)
            {
                return;
            }

            ResizeArray();
            ShiftRight(index);
            list[index] = item;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                return;
            }

            Array.Resize(ref list, 0);
            Count = 0;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly) // A collection that is read-only does not allow removal of elements  after the collection is created.
            {
                return false;
            }

            int countAfterElementIsRemoved = Count - 1;

            RemoveAt(IndexOf(item));

            return Count == countAfterElementIsRemoved;
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index) || IsReadOnly)
            {
                return;
            }

            ShiftLeft(index);
            Count--;
        }

        public void ResizeArray()
        {
            if (list.Length > Count || IsReadOnly)
            {
                return;
            }

            const int doubleTheCapacity = 2;

            Array.Resize(ref list, Count * doubleTheCapacity);
        }

        public bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
            int rightSideLimit = Count;
            for (int i = Count; i >= Count - index; i--)
            {
                list[rightSideLimit] = list[i - 1];
                rightSideLimit--;
            }
        }
    }
}
