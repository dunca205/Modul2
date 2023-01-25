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

    }
}