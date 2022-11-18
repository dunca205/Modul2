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
            if (Count != 0 && this[Count - 1].CompareTo(element) > 0)
            {
                return;
            }

            base.Add(element);
        }

        public override void Insert(int index, T element)
        {
            T leftSideValue = ElementOrDefault(index - 1, element);
            T rightSideValue = ElementOrDefault(index + 1, element);

            if (leftSideValue.CompareTo(element) > 0 || rightSideValue.CompareTo(element) < 0)
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

        // a.CompareTo(b) > 0 , //  elementul a>b
        // a.CompareTo(b) < 0 , //  elementul a < b
        // a.CompareTo(b) = 0, // elementul a = b
    }
}
