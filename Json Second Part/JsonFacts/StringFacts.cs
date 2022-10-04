namespace Json
{
    public class StringFacts
    {
        [Theory]
        [InlineData("\"\\n\"")]
        [InlineData("\"\\r\"")]
        [InlineData("\"\"")]
        [InlineData("\"\\u26Be\"")]
        [InlineData("\"\\\"\"")]
        [InlineData("\"\\/\"")]
        [InlineData("\"a\"")]
        [InlineData("\"abc\"")]
        [InlineData("\"⛅\"")]
        public void IsValidJsonString(string text)
        {
            IMatch match = new JsonString().Match(text);
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void TextContainsUnrecognizedEscapceCharacters()
        {
            IMatch match = new JsonString().Match("\"\\z\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\z\"", match.RemainingText());
        }

        [Fact]
        public void TextEndsWithWithQuotes()
        {
            IMatch match = new JsonString().Match("\"\\n");
            Assert.False(match.Succes());
            Assert.Equal("\"\\n", match.RemainingText());

        }

        [Fact]
        public void IsInvalidHexSequence()
        {
            IMatch match = new JsonString().Match("\"\\u26Bz\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26Bz\"", match.RemainingText());
        }

        [Fact]
        public void IsUnfinisheddHexSequence()
        {
            IMatch match = new JsonString().Match("\"\\u26\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26\"", match.RemainingText());
        }

        [Fact]
        public void ContainsValidHexSequenceAndValidEscapeChar()
        {
            IMatch match = new JsonString().Match("\"\\u26Be\\r\"");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

        }

        [Fact]
        public void ContainsValidHexSequenceValidValidUnicodePointEscapeCharAnd()
        {
            IMatch match = new JsonString().Match("\"\\u26Be \\r\"");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

        }
    }
}
