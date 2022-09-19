namespace Json
{
    public class AnyFacts
    {
        [Fact]
        public void TextStartsWithAnyCharacterFromGivenString()
        {
            var e = new Any("eE");
            IMatch match = e.Match("ea");
            Assert.True(match.Succes()); // true / "a"
            Assert.Equal("a", match.RemainingText());

            match = e.Match("Ea"); // true / "a"
            Assert.True(match.Succes());
            Assert.Equal("a", match.RemainingText());

            match = e.Match("a"); // false / "a"
            Assert.False(match.Succes());
            Assert.Equal("a", match.RemainingText());

            match = e.Match(""); // false / ""
            Assert.False(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = e.Match(null); // false / null
            Assert.False(match.Succes());
            Assert.Equal(null, match.RemainingText());

        }

        [Fact]
        public void TextStartsWithPlusOrMinusSign()
        {
            var sign = new Any("-+");
            IMatch match = sign.Match("+3"); // true / "3"
            Assert.True(match.Succes());
            Assert.Equal("3", match.RemainingText());

            match = sign.Match("+3"); // true / "3"
            Assert.True(match.Succes());
            Assert.Equal("3", match.RemainingText());


            match = sign.Match("-2"); // true  / "2"
            Assert.True(match.Succes());
            Assert.Equal("2", match.RemainingText());

            match = sign.Match("2"); // false / "2"
            Assert.False(match.Succes());
            Assert.Equal("2", match.RemainingText());

            match = sign.Match(""); // false / ""
            Assert.False(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = sign.Match(null); // false / null
            Assert.False(match.Succes());
            Assert.Equal(null, match.RemainingText());
        }
    }
}