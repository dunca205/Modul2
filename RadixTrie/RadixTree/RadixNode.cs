namespace Radix
{
    public class RadixNode<T>
    {
        private SortedList<T, RadixNode<T>> children;
        private T value;

        public RadixNode(T value)
        {
            this.value = value;
            children = new SortedList<T, RadixNode<T>>();
        }

        public SortedList<T, RadixNode<T>> Children { get => this.children; set => this.children = value; }

        public T Value { get => value; set => this.value = value; }

        public bool IsWord { get; set; }
    }
}
