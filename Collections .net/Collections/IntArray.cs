﻿namespace Collections
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            const int minimumCapacity = 4;
            array = new int[minimumCapacity];
        }

        public int Count { get; private set; }

        public virtual int this[int index]
        {
            get => array[index];

            set
            {
                if (!IsValidIndex(index))
                {
                    return;
                }

                array[index] = value;
            }
        }

        public virtual void Add(int element)
        {
            ResizeArray();
            array[Count++] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element, 0, Count);
        }

        public virtual void Insert(int index, int element)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            ResizeArray();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            Count = 0;
        }

        public bool Remove(int element)
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
            if (array.Length > Count)
            {
                return;
            }

            Array.Resize(ref array, Count * doubleTheCapacity);
        }

        public bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}