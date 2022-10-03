namespace Json
{
    public class NumberFacts
    {
        [Theory]
        [InlineData("-123")]
        [InlineData("-1")]
        [InlineData("25")]
        [InlineData("70")]
        [InlineData("0")]
        [InlineData("0.1")]
        [InlineData("12.34")]
        [InlineData("0.0001")]
        [InlineData("10.00000001")]
        [InlineData("12e3")]
        [InlineData("12E3")]
        [InlineData("12e+3")]
        [InlineData("61e-9")]
        [InlineData("12.34E3")]
        [InlineData("0.01e-00")]
        [InlineData("-0.01")]
        public void IsValidJsonNumber(string text)
        {
            IMatch match = new Number().Match(text);
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void ExistentReminder()
        {
            IMatch match = new Number().Match("12E3ANA");
            Assert.Equal("ANA", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void JsonNumberInvalid()
        {
            IMatch match = new Number().Match("-a");
            Assert.Equal("-a", match.RemainingText());
            Assert.False(match.Succes());
        }

        [Fact]
        public void ValidIntegerAndInvalidFraction()
        {
            IMatch match = new Number().Match("-10.r");
            Assert.Equal(".r", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void ValidIntegerAndInvalidExponential()
        {
            IMatch match = new Number().Match("-10E");
            Assert.Equal("E", match.RemainingText());
            Assert.True(match.Succes());
        }

        [Fact]
        public void ValidInteger()
        {
            IMatch match = new Number().Match("-01");
            Assert.Equal("1", match.RemainingText());
            Assert.True(match.Succes());

        }
    }
}
