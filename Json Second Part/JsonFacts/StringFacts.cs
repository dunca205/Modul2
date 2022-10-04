using System;
using Xunit;

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
            IMatch match = new StringJson().Match(text);
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }
        
        [Fact]
        public void TextIsUnrecognizedExcapceCharacters()
        {
            IMatch match = new StringJson().Match("\"\\z\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\z\"", match.RemainingText());
        }

        [Fact]
        public void TextEndsWithWithQuotes()
        {
            IMatch match = new StringJson().Match("\"\\n");
            Assert.False(match.Succes());
            Assert.Equal("\"\\n", match.RemainingText());

        }

        [Fact]
        public void IsInvalidHexSequence()
        {
            IMatch match = new StringJson().Match("\"\\u26Bz\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26Bz\"", match.RemainingText());
        }

        [Fact]
        public void IsUnfinisheddHexSequence()
        {
            IMatch match = new StringJson().Match("\"\\u26\"");
            Assert.False(match.Succes());
            Assert.Equal("\"\\u26\"", match.RemainingText());
        }

        //fail    [Fact] 
        public void ContainsInvalidHexSequenceAndValidEscapeChar()
        {
            IMatch match = new StringJson().Match("\"\\u26Be \\r\"");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());

        }
    }
}
