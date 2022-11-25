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
    }
}
