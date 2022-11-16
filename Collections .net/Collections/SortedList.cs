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
                if (this[index].CompareTo(value) > 0) // daca elementul curent este mai mare decat valoarea nu e ok sa ii schimbam valoarea 
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            if (Count != 0 && this[Count - 1].CompareTo(element) > 0) // ultimul element din sir este mai mare decat elementul pe care vrem sa il adaugam
            {
                return;
            }

            base.Add(element);
        }

        public override void Insert(int index, T element)
        {
            if (!IsValidIndex(index) || this[index - 1].CompareTo(element) > 0 || this[index].CompareTo(element) < 0)
            {
                return;
            }

            base.Insert(index, element);
        }

        // a.CompareTo(b) > 0 , //  elementul a>b
        // a.CompareTo(b) < 0 , //  elementul a < b
        // a.CompareTo(b) = 0, // elementul a = b
    }
}
