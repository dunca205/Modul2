using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Add(int element)
        {
            DoubleTheCapacity();
            base.Add(element);
            BubbleSort();
        }

        public void BubbleSort()
        {
            bool swaped = true;
            for (int i = 0; i < Count - 1 && swaped; i++)
            {
                swaped = false;
                for (int j = i; j < Count - 1; j++)
                {
                    if (this[j + 1] < this[j])
                    {
                        Swap(j + 1, j);
                        swaped = true;
                    }
                }
            }
        }

        public void Swap(int lower, int higher)
        {
            int temp = this[lower];
            this[lower] = this[higher];
            this[higher] = temp;
        }
    }
}
