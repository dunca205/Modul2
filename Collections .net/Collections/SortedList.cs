namespace Collections
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList()
        {
        }

        public override T this[int index]
        {
            set
            {
                T leftSideValue = ElementOrDefault(index - 1, value);
                T rightSideValue = ElementOrDefault(index + 1, value);
                if (leftSideValue.CompareTo(value) > 0 || rightSideValue.CompareTo(value) < 0)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            if (Count != 0 && RightSideIsGreater(Count - 1, element))
            {
                return;
            }

            base.Add(element);
        }

        public override void Insert(int index, T element)
        {
            if (!IsValidIndex(index) || RightSideIsGreater(index - 1, element) || LeftSideIsGreater(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private T ElementOrDefault(int index, T value)
        {
            if (IsValidIndex(index))
            {
                return this[index];
            }

            return value;
        }

        private bool RightSideIsGreater(int index, T value)
        {
            return this[index].CompareTo(value) > 0;
        }

        private bool LeftSideIsGreater(int index, T value)
        {
            return value.CompareTo(this[index]) > 0;
        }

        // a.CompareTo(b) > 0 , //  elementul a>b
        // a.CompareTo(b) < 0 , //  elementul a < b
        // a.CompareTo(b) = 0, // elementul a = b
    }
}
