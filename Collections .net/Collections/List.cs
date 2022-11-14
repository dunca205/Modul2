using System;
using System.Collections;

namespace Collections
{
    public class List<T> : IEnumerable
    {
        private T[] objectList;

        public List()
        {
            const int minimumCapacity = 4;
            objectList = new T[minimumCapacity];
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

                objectList[index] = value;
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
            objectList[Count++] = element;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(objectList, element, 0, Count);
        }

        public virtual void Insert(int index, T element)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            ResizeArray();
            ShiftRight(index);
            objectList[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref objectList, 0);
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
            if (objectList.Length > Count)
            {
                return;
            }

            Array.Resize(ref objectList, Count * doubleTheCapacity);
        }

        public bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                objectList[i] = objectList[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            int rightSideLimit = Count;
            for (int i = Count; i >= Count - index; i--)
            {
                objectList[rightSideLimit] = objectList[i - 1];
                rightSideLimit--;
            }
        }
    }
}
