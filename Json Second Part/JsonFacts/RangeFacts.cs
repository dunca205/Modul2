global using Xunit;
namespace Json
{
    public class RangeFacts
    {
        [Fact]
        public void TextMatchRange()
        {
            var range = new Range('0', '9');
            IMatch match = range.Match("01239");
            Assert.True(match.Succes());
            Assert.Equal("1239", match.RemainingText());
        }
        [Fact]
        public void TextDoesntMatchRange()
        {
            var range = new Range('0', '9');
            IMatch match = range.Match("abcd");
            Assert.False(match.Succes());
            Assert.Equal("abcd", match.RemainingText());
        }

    }
}