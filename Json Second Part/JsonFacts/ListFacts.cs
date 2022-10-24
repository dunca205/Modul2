namespace Json
{
    public class ListFacts
    {
        [Fact]
        public void ListMatchesAllElements()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match("1,2,3"); // true / ""
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void ListDoesntMatchAllElements()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match("1,2,3,"); // true / ""
            Assert.True(match.Succes());
            Assert.Equal(",", match.RemainingText());
        }

        [Fact]
        public void ListMatchesOneElement()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match("1a"); // true / "a"
            Assert.True(match.Succes());
            Assert.Equal("a", match.RemainingText());
        }

        [Fact]
        public void ListDoestnMatchAnyElement()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match("abc"); // true / "abc"
            Assert.True(match.Succes());
            Assert.Equal("abc", match.RemainingText());
        }

        [Fact]
        public void ListDoesntMatchEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match("");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void ListDoesntMatchNullString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch match = a.Match(null);
            Assert.True(match.Succes());
            Assert.Null(match.RemainingText());
        }

        [Fact]
        public void ListMatchesAllCharacters()
        {
            var digits = new OneOrMore(new Range('0', '9'));

            var whitespace = new Many(new Any(" \r\n\t"));

            var separator = new Sequence(whitespace, new Character(';'), whitespace);

            var list = new List(digits, separator);

            IMatch match = list.Match("1; 22  ;\n 333 \t; 22"); // true, ""
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = list.Match("1 \n;"); // true, " \n;"
            Assert.True(match.Succes());
            Assert.Equal(" \n;", match.RemainingText());

            match = list.Match("abc"); // true, "abc"
            Assert.True(match.Succes());
            Assert.Equal("abc", match.RemainingText());

        }
    }
}
