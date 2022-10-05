namespace Json
{
    public class ValueFacts
    {
        [Theory]
        [InlineData("\"abc\"")]
        [InlineData("\"\\n\"")] 
        [InlineData("\"\\u26Be\"")]
        [InlineData("12.3")]
        [InlineData("12.3E-2")]
        [InlineData("0.01e-00")]
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("null")]
        [InlineData("[ ]")]
        [InlineData("[ \n]")]
        [InlineData("{ }")]
        [InlineData("[\"GML\"]")]
        [InlineData("[ \"abc\" , 12.3 , true , null ]")]
        [InlineData("{ \"Ana\" : 23 }")] 
        [InlineData("{ \"Ana\" : 23 , \"Cristina\" : 24 }")]
        [InlineData("{\"value\" : \"Open\" , \"onclick\" : \"OpenDoc()\" }")]
        public void IsValidJson(string text)
        {
            IMatch match = new Value().Match(text);
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Succes());
        }
        [Fact]
        public void IsNotValidJson()
        {
            IMatch match = new Value().Match("abc");
            Assert.Equal("abc", match.RemainingText());
            Assert.False(match.Succes());

        }





    }
}
