namespace Collections
{
    public class IListImplementation<T> : List<T>, IList<T>

   // aici IListImplementation mosteneste din clasa de baza List<T> implementata anterior de mine dar clasa respectiva nu implementeza IList- deci nu este o colectie generica
   //  List<T> impementeza IEnumerable, iar implementand IList<T> pt o colectie de tipul List<T> trebuie sa implemetam suplimentar doar ce nu este deja implementat in List<T>
   // faptul ca implementeza IList<T> face ca IListImplementation - sa devina generica?
    {
        public IListImplementation()
        {
        }

        public bool IsReadOnly { get; }

        public void CopyTo(T[] array, int arrayIndex)
        {
            bool canBeCopied = this.Count <= (array.Length - arrayIndex);
            if (!IsValidIndex(arrayIndex) || !canBeCopied)
            {
                return;
            }

            this.CopyTo(array, arrayIndex); // aici nu copiaza sirul pt ca this(List<T> nu este de tip generic)
        }
    }
}
