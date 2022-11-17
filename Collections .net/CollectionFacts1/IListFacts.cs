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
            list.RemoveAt(1);
            Assert.False(list.Contains(1));
            Assert.Single(list);
        }

        [Fact]
        public void CheckIndexForItem()
        {
            var list = new ILists<int> { 1, 2, 3 };
            Assert.Equal(0, list.IndexOf(1));
            Assert.Equal(3, list.Count);
            var charList = new ILists<char> { 'a', 'b','c' };
            Assert.Equal(-1, charList.IndexOf('f'));
            Assert.Equal(0, charList.IndexOf('a'));
        }

        [Fact]
        public void InsertItemOnList()
        {
            var list = new ILists<int> { 1, 2, 3 };
            list.Insert(0, 1);
            Assert.True(list[0] == 1);
            Assert.True(list[1] == 1);
            Assert.True(list.Count.Equals(4));

        }
    }   
}
