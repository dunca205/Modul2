using System.Net.Http.Headers;

namespace Collections
{
    public class ReadOnlyListFacts
    {
        [Fact]
        public void ConvertListToReadOnly()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Assert.False(list.IsReadOnly);

            var restrictedCollection = new ReadOnlyList<int>(list);
            Assert.True(restrictedCollection.IsReadOnly);
        }

        [Fact]
        public void GetEnumeratorForReadOnlyList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var restrictedCollection = new ReadOnlyList<int>(list);

            var enumerator = restrictedCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.True(enumerator.Current > 0);
            }
        }

        [Fact]
        public void AssignNewValueToReadOnlyCollection()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var restrictedCollection = new ReadOnlyList<int>(list);
            restrictedCollection[1].Equals(3);
            Assert.False(restrictedCollection[1].Equals(3));
        }

        [Fact]
        public void ElementAtIndex()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var restrictedCollection = new ReadOnlyList<int>(list);
            Assert.Equal(1, restrictedCollection[0]);
        }

        [Fact]
        public void AddNewElementToReadOnlyList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Add(3));

        }

        [Fact]
        public void GetElementForIndexLessThanZero()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<ArgumentOutOfRangeException>(() => readOnlyList[-1]);
        }

        [Fact]
        public void SetElementOnReadOnlyList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList[0] = 2);
        }

        [Fact]
        public void ClearReadOnlyArray()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Clear());
        }

        [Fact]
        public void CopyToNullArray()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var readOnlyList = new ReadOnlyList<int>(list);
            int[] arrayToHold = null;
            Assert.Throws<ArgumentNullException>(() => readOnlyList.CopyTo(arrayToHold, 0));
        }

        [Fact]
        public void CopyToArrayStartingWithNegativeIndex()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var readOnlyList = new ReadOnlyList<int>(list);
            int[] arrayToHold = new int[2];
            Assert.Throws<ArgumentOutOfRangeException>(() => readOnlyList.CopyTo(arrayToHold, -1));
        }

        [Fact]
        public void CopyToShoterArray()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var readOnlyList = new ReadOnlyList<int>(list);
            int[] arrayToHold = new int[2];
            Assert.Throws<ArgumentException>(() => readOnlyList.CopyTo(arrayToHold, 1));

        }
    }
}
