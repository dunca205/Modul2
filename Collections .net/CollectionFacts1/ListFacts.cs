namespace Collections
{
    public class ListFacts
    {

        [Fact]
        public void ListOfInt()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            Assert.Equal(4, list.Count);
        }


        [Fact]
        public void ListOfDoubleTypeVariablesCheckCapacityWhenListHas4Elements()
        {
            var list = new List<double> { 1.23, 2.03, 3.12 };
            Assert.Equal(3, list.Count);
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.True(enumerator.Current > 0);
            }
        }

        [Fact]
        public void ListOfCharacters()
        {
            var list = new List<char> { 'a', 'b', 'c' };
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void ListOfStringsCheckLength()
        {
            var list = new List<string> { "ana", "are", "apa" };
            foreach (var word in list)
            {
                Assert.Equal(3, word.Length);
            }
        }

        [Fact]
        public void EnumerateElementsOfSameLengthFromList()
        {
            var list = new List<string> { "ana", "are", "apa" };
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.Equal(3, enumerator.Current.Length);
            }
        }

        [Fact]
        public void CoppyListToArrayStartingWithIndexZero()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var arrayToHold = new int[6];
            list.CopyTo(arrayToHold, 0);
            Assert.True(arrayToHold[0].Equals(1));
            Assert.True(arrayToHold[2].Equals(3));
        }

        [Fact]
        public void CoppyListToArrayStartingWithIndex3()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var arrayToHold = new int[8];
            list.CopyTo(arrayToHold, 3);
            Assert.Equal(1, arrayToHold[3]);
        }

        [Fact]
        public void CoppyListToArrayWhenArraysLengthIsNotEnough()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var arrayToHold = new int[5];
            Assert.Throws<ArgumentException>(() => list.CopyTo(arrayToHold, 3));
        }

        [Fact]
        public void CoppyListToArrayWhenArrayIsPerfectSize()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var arrayToHold = new int[5];
            list.CopyTo(arrayToHold, 0);
            Assert.Equal(1, arrayToHold[0]);

        }

        [Fact]
        public void CoppyListWithOnly5ItemsWhenArrayLengthIs5()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var arrayToHold = new int[6];
            list.CopyTo(arrayToHold, 0);
            Assert.Equal(5, arrayToHold[4]);

        }

        [Fact]
        public void InsertElementInList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            list.Insert(4, 8);
            Assert.Equal(8, list[4]);
        }


        [Fact]
        public void CollectionIsReadOnly()
        {
            var list = new List<int> { };
            Assert.False(list.IsReadOnly);
        }
    }
}