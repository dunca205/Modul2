using Xunit;
namespace Dictionary
{
    public class DictionaryFacts
    {
        [Fact]
        public void GetBucketReturnsTheReminderBasedOnSize()
        {
            var dictionar = new Dictionary<int, string>(5);
            Assert.Equal(0, dictionar.GetBucket(10));
            Assert.Equal(1, dictionar.GetBucket(1));
            Assert.Equal(2, dictionar.GetBucket(2));
            Assert.Equal(2, dictionar.GetBucket(7));
            Assert.Equal(2, dictionar.GetBucket(12));
        }

        [Fact]
        public void AddOneElementInEachBucket()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal(5, dictionar.Count);
        }

        [Fact]
        public void SearchForKeyThatIsPresentInDictioanry()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            Assert.True(dictionar.ContainsKey(1));
        }

        [Fact]
        public void SearchForKeyThatIsNotPesent()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            Assert.False(dictionar.ContainsKey(4));
        }

        [Fact]
        public void FindValueForCertainKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal("d", dictionar[7]);
        }

        [Fact]
        public void SetNewValueForCertainKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar[2] = "c";
            Assert.Equal("c", dictionar[2]);
        }

        [Fact]
        public void TryGetValueForExistentKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            Assert.True(dictionar.TryGetValue(2, out var value));
            Assert.Equal("b", value);
        }

        [Fact]
        public void TryGetValueForInexistentKey()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            Assert.False(dictionar.TryGetValue(4, out var invalid));
            Assert.Null(invalid);
        }

        [Fact]
        public void CheckNextPointer()
        {
            var dictionar = new Dictionary<int, string>(5);
            dictionar.Add(1, "a");
            dictionar.Add(2, "b");
            dictionar.Add(10, "c");
            dictionar.Add(7, "d");
            dictionar.Add(12, "e");
            Assert.Equal(-1, dictionar.GetElement(2).Next);
            Assert.Equal(1, dictionar.GetElement(7).Next);
            Assert.Equal(3, dictionar.GetElement(12).Next);
        }
        

    }
}