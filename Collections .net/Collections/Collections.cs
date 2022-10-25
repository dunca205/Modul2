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

        public int AvaiablePosition()
        {
            foreach (var number in array)
            {
                if (number.Equals(0))
                {
                    return IndexOf(number);
                }
            }

            return -1;
        }

        public void Add(int element)
        {
            if (AvaiablePosition() > -1)
            {
                array[AvaiablePosition()] = element;
                return;
            }

            Array.Resize(ref array, array.Length * 2);
            array[AvaiablePosition()] = element;
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return array.Contains(element);
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            array[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
        }

        public void Remove(int element)
        {
            if (IndexOf(element) > -1)
            {
                array[IndexOf(element)] = 0;
            }
        }

        public void RemoveAt(int index)
        {
            array[index] = 0;
        }

    }
}