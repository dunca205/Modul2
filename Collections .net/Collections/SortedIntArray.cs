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
                if (index < 0 || index >= Count)
                {
                    return;
                }

                if (index == 0 || index == Count - 1)
                {
                    if (index == 0 && index < Count && base[index + 1] > value)
                    {
                        base[index] = value;
                    }

                    if (index == Count - 1 && base[index - 1] < value)
                    {
                        base[index] = value;
                    }

                    return;
                }

                if (base[index - 1] > value || base[index + 1] < value)
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

        private bool IsSpecialCase(int index)
        {
            if (index == 0 || index == Count - 1)
            {
                if (index == 0 && index < Count && base[index + 1] > value)
                {
                    base[index] = value;
                }

                if (index == Count - 1 && base[index - 1] < value)
                {
                    base[index] = value;
                }

                return;
            }

        }
    }
}
