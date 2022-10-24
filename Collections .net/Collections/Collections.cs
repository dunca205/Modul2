namespace Collections
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            array = Array.Empty<int>();
        }

        static void Main()
        {

        }

        public void Add(int element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = element;
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

        public void Clear() // aici nu stiu daca trebuie sa fie un sir cu 0 elemente sau sa se stearga doar valoarea de pe fiecare pozitie si sa ramana 0
        {
            Array.Resize(ref array, 0);
        }

        public void Remove(int element)
        {
            array[IndexOf(element)] = 0;
        }

        public void RemoveAt(int index)
        {
            array[index] = 0;
        }

    }
}