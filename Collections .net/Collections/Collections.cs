namespace Collections
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
            if (count < array.Length)
            {
                array[count] = element;
                count++;
                return;
            }

            Array.Resize(ref array, count * 2);
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
            count = 0;
        }

        public void Remove(int element)
        {
            if (IndexOf(element) > -1)
            {
                array[IndexOf(element)] = 0;
                count--;
            }
        }

        public void RemoveAt(int index)
        {
            array[index] = 0;
            count--;
        }

    }
}