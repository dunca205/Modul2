namespace Radix
{
    public class RadixNode<T>
    {
        private SortedList<char, RadixNode<T>> children;

        public RadixNode(T value)
        {
            this.Value = value;
            children = new SortedList<char, RadixNode<T>>();
        }

        public SortedList<char, RadixNode<T>> Children { get => this.children; }

        public T Value { get; set; }

        public bool IsWord { get; set; }
    }
}
