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

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => list[index];

            set
            {
                if (!IsValidIndex(index))
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
         //   list.CopyTo(array, arrayIndex);
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
            if (!IsValidIndex(index))
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
            if (!IsValidIndex(index))
            {
                return;
            }

            ShiftLeft(index);
            Count--;
        }

        public void ResizeArray()
        {
            const int doubleTheCapacity = 2;
            if (list.Length > Count)
            {
                return;
            }

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
