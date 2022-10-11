namespace Json
{
    public class TextFacts
    {
        [Fact]
        public void TextMatchesGivenPrefix()
        {
            var textTrue = new Text("true");
            var textFalse = new Text("false");

            IMatch match = textTrue.Match("true"); // true / ""
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = textTrue.Match("trueX"); // true / "X"
            Assert.True(match.Succes());
            Assert.Equal("X", match.RemainingText());

            match = textTrue.Match("false"); // false / "false"
            Assert.False(match.Succes());
            Assert.Equal("false", match.RemainingText());

            match = textTrue.Match(""); //false / ""
            Assert.False(match.Succes());
            Assert.Equal("", match.RemainingText());


            match = textTrue.Match(null); // false / null
            Assert.False(match.Succes());
            Assert.Equal(null, match.RemainingText());

            match = textFalse.Match("false");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());


            match = textFalse.Match("falseX"); // true / "X"
            Assert.True(match.Succes());
            Assert.Equal("X", match.RemainingText());

            match = textFalse.Match("true"); // false / "true"
            Assert.False(match.Succes());
            Assert.Equal("true", match.RemainingText());

            match = textFalse.Match("");
            Assert.False(match.Succes());
            Assert.Equal("", match.RemainingText());

            match = textFalse.Match(null);
            Assert.False(match.Succes());
            Assert.Equal(null, match.RemainingText());

        }
        [Fact]
        public void TextMatchesNullOrEmptyPrefix()
        {
            var empty = new Text("");
            IMatch match = empty.Match("true");// true / "true"
            Assert.True(match.Succes());
            Assert.Equal("true", match.RemainingText());

            match = empty.Match(null); // false / null
            Assert.False(match.Succes());
            Assert.Equal(null, match.RemainingText());

        }
    }
}