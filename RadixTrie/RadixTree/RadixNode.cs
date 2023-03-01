namespace Radix
{
    public class RadixNode<T>
    where T : IComparable<T>
    {
        public RadixNode(T value)
        {
            this.Value = value;
            Children = new SortedList<T, RadixNode<T>>();
        }

        public SortedList<T, RadixNode<T>> Children { get; set; }

        public T Value { get; set; }

        public bool IsWord { get; set; }

        public int CompareTo(RadixNode<T>? other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
