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
        public void EnumerateElementsInList()
        {
            var list = new List<string> { "ana", "are", "apa" };
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.Equal(3, enumerator.Current.Length);
            }
        }
    }
}