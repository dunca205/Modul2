namespace Radix
{
    public class RadixNode<T>
    {
        public RadixNode(T value)
        {
            this.Value = value;
            Children = new SortedList<T, RadixNode<T>>();
        }

        public SortedList<T, RadixNode<T>> Children { get; set; }

        public T Value { get; set; }

        public bool IsWord { get; set; }

        public int CompareTo(T? other)
        {
            string existStr = Value.ToString();
            string newStr = other.ToString();
            string left = "";

            for (int i = 0; i < existStr.Length && i < newStr.Length; i++)
            {
                if (newStr[i] != existStr[i])
                {
                    break;
                }

                left += newStr[i];
            }

            if (left.Length.CompareTo(existStr.Length) == 0)
            {
                return 0; // x este prefix perfect pt y
            }
            else if (left.Length.CompareTo(existStr.Length) < 0 && left.Length > 0)
            {
                return 1; // x este prefix partial pentru y
            }

            return -1;
        }
    }
}
