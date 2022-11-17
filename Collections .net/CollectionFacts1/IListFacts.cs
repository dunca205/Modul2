using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class IListFacts
    {
        [Fact]
        public void AddItemsOnList()
        {
            var list = new ILists<int> { 1, 2, 3 };
            Assert.True(list.Contains(1));
        }

        [Fact]
        public void RemoveItemsFromList() 
        {
            var list = new ILists<int> { 1, 2, 3 };
            list.Remove(1);
            list.RemoveAt(2);
            Assert.False(list.Contains(1));
        }
    }
}
