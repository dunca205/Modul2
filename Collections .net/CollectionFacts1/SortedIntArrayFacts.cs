using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void AddNewElementOnSortedArray()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(5);
            sortedArray.Add(4);
            Assert.Equal(3, sortedArray.IndexOf(4));
        }
       
    }
}
