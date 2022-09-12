global using Xunit;
namespace Json
{
    public class RangeFacts
    {
        [Fact]
        public void StringIsInRange()
        {
            var range = new Range(start: 'a', end: 'f');
            Assert.True(range.Match("abc"));
            Assert.True(range.Match("fab"));
            Assert.True(range.Match("bcd"));
        }

        [Fact]
        public void StringIsNotInRange()
        {
            var range = new Range(start: 'a', end: 'f');
            Assert.False(range.Match("1ab"));
            Assert.False(range.Match(null));
            Assert.False(range.Match(string.Empty));

        }

    }
}