namespace Collections
{
    public class IListFacts
    {
        [Fact]
        public void AddItemsOnList()
        {
            var list = new ILists<int> { 1, 2, 3 };
            Assert.Contains(1, list);
        }

        [Fact]
        public void RemoveItemsFromList()
        {
            var list = new ILists<int> { 1, 2, 3 };
            list.Remove(1);
            list.RemoveAt(1);
            Assert.DoesNotContain(1, list);
            Assert.Single(list);
        }

        [Fact]
        public void CheckIndexForItem()
        {
            var list = new ILists<int> { 1, 2, 3 };
            Assert.Equal(0, list.IndexOf(1));
            Assert.Equal(3, list.Count);
            var charList = new ILists<char> { 'a', 'b', 'c' };
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

        [Fact]
        public void CopyToSmallerLengthArray()
        {
            var listOfElements = new ILists<int> { 1, 2, 3, 4, 5, 6 };
            var arrayToStore = new int[5];
            listOfElements.CopyTo(arrayToStore, 0);
            Assert.DoesNotContain(1, arrayToStore);
            Assert.False(arrayToStore[0].Equals(1));

        }

        [Fact]
        public void CoppyToLargerLengthArrayStartingAtIndex1()
        {
            var listOfElements = new ILists<int> { 1, 2, 3, 4, 5, 6 };
            var arrayToStore = new int[7];
            listOfElements.CopyTo(arrayToStore, 1);
            Assert.True(arrayToStore[1].Equals(1));

        }

        [Fact]
        public void CoppyToArrayStartingWithIndexLargerThanTheArrayLength()
        {
            var listOfElements = new ILists<int> { 1, 2, 3, 4, 5, 6 };
            var arrayToStore = new int[7];
            listOfElements.CopyTo(arrayToStore, 8);
            Assert.DoesNotContain(6, arrayToStore);
        }
    }
}
