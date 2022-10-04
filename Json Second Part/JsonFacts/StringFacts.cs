namespace Json
{
    public class StringFacts
    {
        [Theory]
        [InlineData("\"\\n\"")]
        [InlineData("\"\\r\"")]
        //   [InlineData("\"\"")]
        [InlineData("\"\\u26Be\"")]
        [InlineData("\"\\\"\"")]
        [InlineData("\"\\/\"")]
        [InlineData("\"a\"")]
        [InlineData("\"⛅\"")]

        //  [InlineData("\"abc\"")]
        public void IsValidJsonString(string text)
        {
            IMatch match = new String().Match(text);
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void TextContainsUnrecognizedEscapceCharacters()
        {
            IMatch match = new String().Match("\"\\z\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\z\"", match.RemainingText());
        }

        [Fact]
        public void TextEndsWithWithQuotes()
        {
            IMatch match = new String().Match("\"\\n");
            Assert.False(match.Succes());
            Assert.Equal("\"\\n", match.RemainingText());

        }

        [Fact]
        public void IsInvalidHexSequence()
        {
            IMatch match = new String().Match("\"\\u26Bz\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26Bz\"", match.RemainingText());
        }

        [Fact]
        public void IsUnfinisheddHexSequence()
        {
            IMatch match = new String().Match("\"\\u26\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26\"", match.RemainingText());
        }

        //fail    [Fact] 
        public void ContainsInvalidHexSequenceAndValidEscapeChar()
        {
            IMatch match = new String().Match("\"\\u26Be \\r\"");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

        }
    }
}
