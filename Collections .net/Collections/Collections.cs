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

        public void DoubleTheCapacity()
        {
            if (count >= array.Length)
            {
                Array.Resize(ref array, count * 2);
            }
        }

        public void Add(int element)
        {
            DoubleTheCapacity();
            array[count++] = element;
        }

        public (int[], int[]) SplitArrayAtCertainIndex(int index)
        {
            int[] arrayBeforeIndex = new int[index];
            int[] arrayFromIndex = new int[count - index];
            Array.Copy(array, 0, arrayBeforeIndex, 0, index);
            Array.Copy(array, index, arrayFromIndex, 0, count - index);
            return (arrayBeforeIndex, arrayFromIndex);
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
            DoubleTheCapacity();

            (int[] fistpartofarray, int[] secondpartofarray) = SplitArrayAtCertainIndex(index);

            Array.Resize(ref fistpartofarray, fistpartofarray.Length + 1);
            fistpartofarray[^1] = element;
            Array.Copy(fistpartofarray, 0, fistpartofarray, 0, fistpartofarray.Length - 1);

            array = fistpartofarray.Concat(secondpartofarray).ToArray();
            count++;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
            count--;
        }

        public void RemoveAt(int index)
        {
            (int[] fistpartofarray, int[] secondpartofarray) = SplitArrayAtCertainIndex(index);
            array = fistpartofarray.Concat(secondpartofarray[1..]).ToArray();
            count--;
        }
    }
}