namespace Collections
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

        public int this[int index]
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

        public void Add(int element)
        {
            DoubleTheCapacity();
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

        public void Insert(int index, int element)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            DoubleTheCapacity();
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

        private bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        private void DoubleTheCapacity()
        {
            if (array.Length > Count)
            {
                return;
            }

            Array.Resize(ref array, Count * 2);
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
            for (int i = Count; i > Count - index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}