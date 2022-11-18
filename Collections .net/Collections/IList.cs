using System.Collections;

namespace Collections
{
    public class ILists<T> : IList<T>
    {
        private readonly IList<T> list;

        public ILists()
        {
            list = new System.Collections.Generic.List<T>();

            // ILists = este de tipul List<T>() ; nu de tipul clasei definite de mine care are acelasi nume
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => list[index];

            set
            {
                if (!IsValidIndex(index))
                {
                    return;
                }

                list[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public virtual void Add(T item)
        {
            list.Add(item);
            Count++;
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            list.Insert(index, item);
            Count++;
        }

        public void Clear()
        {
            list.Clear();
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index))
            {
                return;
            }

            Count--;
            list.RemoveAt(index);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            bool canBeCopied = this.Count <= (array.Length - arrayIndex); // ma asigur ca sirul este suficient de mare sa poata copia toate elementele
            if (!IsValidIndex(arrayIndex) || !canBeCopied)
            {
                return;
            }

            list.CopyTo(array, arrayIndex); // aici copiaza pt ca list este de tip generic 
        }

        public bool IsValidIndex(int index)
        {
            return index > -1 && index < Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (!IsValidIndex(IndexOf(item)))
            {
                return false;
            }

            Count--;
            return list.Remove(item);
        }
    }
}
