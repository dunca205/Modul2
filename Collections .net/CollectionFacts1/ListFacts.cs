using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFacts
{
    public class ListFacts
    {
        [Fact]
        public void ListOfIntVariablesCheckValue()
        {
            var list = new List<int> { 1, 2, 3 };
            foreach (var number in list)
            {
                Assert.True(number > 0);
            }
        }

        [Fact]
        public void ListOfDoubleTypeVariablesCheckCapacityWhenListHas4Elements()
        {
            var list = new List<double> { 1, 2.12, 34.02, 3 };
            Assert.True(list.Capacity.Equals(4));
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.True(enumerator.Current > 0);
            }
        }

        [Fact]
        public void ListOfCharactersCheckCapacityWhenListContains5Elements()
        {
            var list = new List<char> { 'a', 'b', 'c', 'd', 'e' };
            Assert.True(list.Capacity.Equals(8));
            Assert.True(list.Count.Equals(5));
        }

        [Fact]
        public void ListOfStringsCheckLength()
        {
            var list = new List<string> { "ana", "are", "apa" };
            foreach(var word in list)
            {
                Assert.Equal(3, word.Length);
            }
        }

        [Fact]
        public void EnumerateElementsInList()
        {
            var list = new List<string> { "ana", "are", "apa" };
            var enumerator = list.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Assert.Equal(3, enumerator.Current.Length);
            }
        }
    }
}
