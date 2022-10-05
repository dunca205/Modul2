namespace Json
{
    public class ValueFacts
    {
        [Theory]
        [InlineData("\"abc\"")] // string 
        [InlineData("\"\\n\"")] // string escapechar
        [InlineData("\"\\u26Be\"")] // string unicode
        [InlineData("123")] // numar
        [InlineData("12.3")] // numar fract
        [InlineData("12.3E-2")] // numar exp
        [InlineData("0.01e-00")] // numar cu fract si exp neg
        [InlineData("true")]
        [InlineData("false")]
        [InlineData("null")]
        [InlineData("[ ]")] // array cu 1whitespace
        [InlineData("[ \n]")] // array cu 2 whitespace
        [InlineData("{ }")] // obiect gol
        [InlineData("[\"GML\"]")]
        [InlineData("[ \"abc\" , 12.3 , true , null ]")] // array de values 
        [InlineData("{ \"Ana\" : 23 }")] // obiect { spatiu string spatiu : spatiu numar spatiu }
        [InlineData("{ \"Ana\" : 23 , \"Cristina\" : 24 }")] // mai multe obiecte 
                                                             // [InlineData("{ \"value\" : \"Open\" , \"onclick\" : \"OpenDoc()\" }")] 
        public void IsValidJson(string text)
        {
            IMatch match = new Value().Match(text);
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Succes());
        }





    }
}
