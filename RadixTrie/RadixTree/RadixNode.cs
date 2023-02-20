namespace Radix
{
    public class RadixNode<T>
    {
        private SortedList<char, RadixNode<string>> children;

        public RadixNode(string value)
        {
            this.Value = value;
            children = new SortedList<char, RadixNode<string>>();
        }

        public SortedList<char, RadixNode<string>> Children { get => this.children; }

        public string Value { get; set; }

        public bool IsWord { get; set; }
    }
}
