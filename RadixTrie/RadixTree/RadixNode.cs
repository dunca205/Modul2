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
    }
}
