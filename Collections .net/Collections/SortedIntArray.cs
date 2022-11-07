namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (!IsValidIndex(index) || this[index - 1] > value || this[index + 1] < value)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(int element)
        {
            if (Count != 0 && this[Count - 1] > element)
            {
                return;
            }

            base.Add(element);
        }

        public override void Insert(int index, int element)
        {
            if (index > 0 && this[index - 1] > element || this[index] < element)
            {
                return;
            }

            base.Insert(index, element);
        }
    }
}
