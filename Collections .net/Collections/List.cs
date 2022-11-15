using System;
using System.Collections;

namespace Collections
{
    public class List<T> : IEnumerable
    {
        private T[] list;

        public List()
        {
            const int minimumCapacity = 4;
            list = new T[minimumCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get => this[index];

            set
            {
                if (!IsValidIndex(index))
                {
                    return;
                }

                list[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public virtual void Add(T element)
        {
            ResizeArray();
            list[Count++] = element;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(list, element, 0, Count);
        }

        public virtual void Insert(int index, T element)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            ResizeArray();
            ShiftRight(index);
            list[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref list, 0);
            Count = 0;
        }

        public bool Remove(T element)
        {
            int countAfterElementIsRemoved = Count - 1;

            RemoveAt(IndexOf(element));

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
