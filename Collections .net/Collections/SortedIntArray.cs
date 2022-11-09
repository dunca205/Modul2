namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray()
        {
        }

        public override int this[int index]
        {
            set
            {
                if (ElementOrDefault(index - 1, value) > value || value > ElementOrDefault(index + 1, value))
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
            if (ElementOrDefault(index - 1, element) > element || element > ElementOrDefault(index + 1, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private int ElementOrDefault(int index, int value)
        {
            if (IsValidIndex(index))
            {
                return this[index];
            }

            return value;
        }
    }
}
