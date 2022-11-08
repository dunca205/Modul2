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

                if (!HasRightValueOnRightOrLeftSide(index, value) && !HasRightValuesOnRightAndLeftSide(index, value))
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

        private bool HasRightValueOnRightOrLeftSide(int index, int value)
        {
            if (index == 0 && NewValueCanBeSetOnIndexZero(value))
            {
                return true;
            }

            if (index == Count - 1 && base[index - 1] < value)
            {
                return true;
            }

            return false;
        }

        private bool NewValueCanBeSetOnIndexZero(int value)
        {
            if (Count == 1) // daca avem doar un element in sir il putem inlocui cu orice pt ca nu avem repere de comparatie
            {
                return true;
            }

            if (base[1] > value) // daca nu s a oprit la primul if , ne asiguram ca value este in continuare mai mica decat valoarea de pe urmatoare pozitie
            {
                return true;
            }

            return false;
        }

        private bool HasRightValuesOnRightAndLeftSide(int index, int value)
        {
            return base[index - 1] < value && base[index + 1] > value;
        }
    }
}
