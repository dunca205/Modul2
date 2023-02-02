namespace Dictionary
{
    public class Entry<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public Entry(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
            this.Next = -1;
        }

        public TKey Key { get => this.key; set => this.key = value; }

        public TValue Value { get => this.value; set => this.value = value; }

        public int Next { get; set; }
    }
}