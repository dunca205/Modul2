namespace Json
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void PatternMatchesEntireText()
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match("123");
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void PatternMatchesOneCharacter()
        {

            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match("1a"); // true / "a"
            Assert.Equal("a", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void PatternDoesnMatchText()
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match("bc"); // false / "bc"
            Assert.Equal("bc", match.RemainingText());
            Assert.False(match.Succes());
        }

        [Fact]
        public void PatternDoesntMatchEmptyString()
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match(""); // false / ""
            Assert.Equal("", match.RemainingText());
            Assert.False(match.Succes());
        }

        [Fact]
        public void PatternDoesnMatchNullString()
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match(null); // false / null
            Assert.Equal(null, match.RemainingText());
            Assert.False(match.Succes());
        }

    }
}

