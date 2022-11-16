using Xunit.Sdk;

namespace Collections
{
    public class SortedListFacts
    {
        [Fact]
        public void AddNumbersInAscendingOrder()
        {
            var sortedList = new SortedList<int> { 1, 2, 3 };
            Assert.Equal(3, sortedList.Count);
        }

        [Fact]
        public void AddNumbersInDescendingOrder()
        {
            var sortedList = new SortedList<int> { 1, 2, 3, -1, 0 };
            Assert.Equal(3, sortedList.Count);
        }

        [Fact]
        public void SetLargerValueThatKeepsTheAscendingOrder()
        {
            var sortedList = new SortedList<int> { 1, 2, 3 };
            sortedList[2] = 4;
            Assert.Equal(4, sortedList[2]);
        }

        [Fact]
        public void SetLargerValueOnPositionThatHasLeftAndRightValues()
        {
            var sortedList = new SortedList<int> { 1, 3, 6, 7 };
            sortedList[1] = 2;
            Assert.True(sortedList[1].Equals(2));

        }


        [Fact]
        public void SetSmallerValueThatWouldChangeTheAsceningOrder()
        {
            var sortedList = new SortedList<int> { 1, 3, 5, 7, 9 };
            sortedList[2] = 2;
            Assert.False(sortedList[2].Equals(2));
        }

        [Fact]
        public void InsertElementOnProperPosition()
        {
            var sortedList = new SortedList<int> { 1, 4, 6 };
            sortedList.Insert(1, 2);
            sortedList.Insert(2, 3);
            Assert.Equal(2, sortedList[1]);
            Assert.Equal(3, sortedList[2]);
        }

        [Fact]
        public void InsertElementWithSameValue()
        {
            var sortedList = new SortedList<int> { 1, 4, 6 };
            sortedList.Insert(2, 6);
            Assert.Equal(4, sortedList.Count);
            Assert.Equal(6, sortedList[2]);
            Assert.Equal(6, sortedList[3]);

        }

        [Fact]
        public void InsertElementOnImproperPosition()
        {
            var sortedList = new SortedList<int> { 1, 3, 5, 6, 7 };
            sortedList.Insert(1, 6);
            Assert.Equal(3, sortedList[1]);
        }

        [Fact]
        public void ListOfCharactersInAlphabeticalOrder()
        {
            var sortedList = new SortedList<char> { 'a', 'b', 'c', 'd' };
            Assert.Equal(4, sortedList.Count);
        }

        [Fact]
        public void ListOfCharactersNotAllOfThemRespectTheAlphabeticalOrder()
        {
            var sortedList = new SortedList<char> { 'a', 'd', 'b', 'e' };
            Assert.Equal(3, sortedList.Count);
        }

        [Fact]
        public void ListOrWordsRespectingTheAlphabelicalOrder()
        {
            var sortedList = new SortedList<string> { "any", "bear", "dogs", "food" };
            Assert.Equal(4, sortedList.Count);
        }

        [Fact]
        public void ListOfWordsNotAllOfThemRespectTheAlphabeticalOrder()
        {
            var sortedList = new SortedList<string> { "bear", "cats", "antelope", "dogs", "zebra", "hamster" };
            Assert.Equal(4, sortedList.Count);

        }
    }
}
