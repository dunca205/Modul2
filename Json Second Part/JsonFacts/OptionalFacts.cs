namespace Json
{
    public class OptionalFacts
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("bc")]
        public void RemovesMatchingPatterFromGivenTextIfItsFound(string text)
        {
            var a = new Optional(new Character('a'));
            IMatch match = a.Match(text);
            Assert.Equal("bc", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Theory]
        [InlineData("123")]
        [InlineData("-123")]
        public void RemovesNegativeSignFromTextIfItsFound(string text)
        {
            var sign = new Optional(new Character('-'));
            IMatch match = sign.Match(text);
            Assert.Equal("123", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void PatternDoesntMatchGivenText()
        {
            var a = new Optional(new Character('a'));
            IMatch match = a.Match("");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = a.Match(null);
            Assert.True(match.Succes());
            Assert.Null(match.RemainingText());
        }

        [Fact]
        public void RemovesOneMatchingPatternFromGivenText()
        {
            var a = new Optional(new Character('a'));
            IMatch match = a.Match("aabc");
            Assert.Equal("abc", match.RemainingText());
            Assert.True(match.Succes());
        }
    }
}