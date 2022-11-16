using System.Collections;

namespace Collections
{
    public class ObjectArray : IEnumerable
    {
        private object[] objectArray;

        public ObjectArray()
        {
            const int minimumCapacity = 4;
            objectArray = new object[minimumCapacity];
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get => objectArray[index];

            set
            {
                if (!IsValidIndex(index))
                {
                    return;
                }

                objectArray[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public virtual void Add(object element)
        {
            ResizeArray();
            objectArray[Count++] = element;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            return Array.IndexOf(objectArray, element, 0, Count);
        }

        public virtual void Insert(int index, object element)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            ResizeArray();
            ShiftRight(index);
            objectArray[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref objectArray, 0);
            Count = 0;
        }

        public bool Remove(object element)
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
            if (objectArray.Length > Count)
            {
                return;
            }

            Array.Resize(ref objectArray, Count * doubleTheCapacity);
        }

        public bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                objectArray[i] = objectArray[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            int rightSideLimit = Count;
            for (int i = Count; i >= Count - index; i--)
            {
                objectArray[rightSideLimit] = objectArray[i - 1];
                rightSideLimit--;
            }
        }
    }
}
