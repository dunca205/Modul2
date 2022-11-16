namespace Collections
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override void Add(T element)
        {
            if (Count != 0 && this[Count - 1].CompareTo(element) < 0)
            {
                return;
            }

            base.Add(element);
        }

        public int CompareTo(T other, T theOtherOne)
        {
            if (other == null)
            {
                return 1;
            }

            return other.CompareTo(theOtherOne);
        }

        public override void Insert(int index, T element)
        {
            if (ElementOrDefault(index - 1, element).CompareTo(element) > 0 || element.CompareTo(ElementOrDefault(index + 1, element)) > 0)
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
    }
}
