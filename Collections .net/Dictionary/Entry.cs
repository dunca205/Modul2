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
        public int Next { get; set; }
        public int Index { get; set; }
    }
}

