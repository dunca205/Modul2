namespace Collections
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void SetGreaterElement_OnCertainPoisition_GivenElementWontChangeTheAscendingOrder()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            sortedArray.Add(6);
            sortedArray.Add(7);
            sortedArray[2] = 4;
            Assert.Equal(4, sortedArray[2]);
        }

        [Fact]
        public void SetElementIndex0()
        {

            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            sortedArray.Add(6);
            sortedArray[0] = 0;
            Assert.Equal(0, sortedArray[0]);
        }

        [Fact]
        public void SetelementOnNegativeIndex()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            sortedArray.Add(6);
            sortedArray[-1] = 3;
            Assert.Equal(6, sortedArray[2]);
        }
        [Fact]
        public void SetNewValueForLastElement()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            sortedArray.Add(6);
            sortedArray[2] = 5;
            sortedArray[2] = 2;
            Assert.Equal(5, sortedArray[2]);
        }

        [Fact]
        public void SetGreaterElement_OnCertainPoisition_GivenElementWouldChangeTheAscendingOrder()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            sortedArray.Add(6);
            sortedArray.Add(7);
            sortedArray[2] = 9;
            Assert.Equal(6, sortedArray[2]);
        }

        [Fact]
        public void AddNewElementGreaterThanThePreviousOne()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(2);
            Assert.Equal(2, sortedArray[1]);
        }

        [Fact]
        public void AddNewElementEqualWithThePreviousOne()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(4);
            sortedArray.Add(5);
            sortedArray.Add(5);
            Assert.Equal(5, sortedArray[4]);
            Assert.Equal(5, sortedArray[5]);
        }

        [Fact]
        public void AddNewElementLesserThanThePreviousOne()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(2);
            Assert.Equal(0, sortedArray[3]);
        }

        [Fact]
        public void InsertNewElemetsThatWontModifyTheAscendingOrder()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(4);
            sortedArray.Add(6);
            sortedArray.Insert(1, 2);
            sortedArray.Insert(2, 3);
            Assert.Equal(2, sortedArray[1]);
            Assert.Equal(3, sortedArray[2]);
        }

        [Fact]
        public void InsertNewElementThatWouldModifyTheAscendingOrder()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(4);
            sortedArray.Add(6);
            sortedArray.Insert(1, 8);
            Assert.Equal(4, sortedArray[1]);
        }

        [Fact]
        public void InsertNewElementEqualWithTheOneFromTheGivenIndex()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(4);
            sortedArray.Add(6);
            sortedArray.Insert(1, 4); // 1 4 4 6
            Assert.Equal(4, sortedArray[1]);
            Assert.Equal(4, sortedArray[2]);
        }


    }
}
