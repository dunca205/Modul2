using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class ILists<T> : IList<T>
    {
        private readonly IList<T> list;

        public ILists()
        {
            list = new System.Collections.Generic.List<T>();
        }

        public int Count { get; }

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

            list.RemoveAt(index);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
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
            return list.Remove(item);
        }
    }
}
