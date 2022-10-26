﻿namespace Collections
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            const int minimumCapacity = 4;
            array = new int[minimumCapacity];
            count = 0;
        }

        public void Add(int element)
        {
            DoubleTheCapacity();
            array[count++] = element;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < count)
            {
                array[index] = element;
            }
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            int indexOfElement = Array.IndexOf(array, element);

            if (indexOfElement >= 0 && indexOfElement < count)
            {
                return indexOfElement;
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            DoubleTheCapacity();
            ShiftRight(index);
            array[index] = element;
            count++;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public void Remove(int element)
        {
            if (IndexOf(element) != -1)
            {
                ShiftLeft(IndexOf(element));
                count--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < count  && index > -1)
            {
                ShiftLeft(index);
                count--;
            }
        }

        private void DoubleTheCapacity()
        {
            if (count >= array.Length)
            {
                Array.Resize(ref array, count * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = count; i > count - index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}