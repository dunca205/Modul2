using Xunit;

namespace Json
{
    public class ManyFacts
    {
        [Fact]
        public void Test1()
        {
            var a = new Many(new Character('a'));
            IMatch match = a.Match("abc");
            Assert.True(match.Succes());
            Assert.Equal("bc", match.RemainingText());
         
            match =  a.Match("aaaabc"); // true / "bc"
            Assert.True(match.Succes());
            Assert.Equal("bc", match.RemainingText());

            match = a.Match("bc"); // true / "bc"
            Assert.True(match.Succes());
            Assert.Equal("bc", match.RemainingText());

            match =  a.Match(""); // true / ""
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
            
             match = a.Match(null); // true / null
            Assert.True(match.Succes());
            Assert.Equal(null, match.RemainingText());

        }
        [Fact]
        public void Test2()
        {
            var digits = new Many(new Range('0', '9'));
            
            IMatch match = digits.Match("12345ab123"); // true / "ab123"
            Assert.True(match.Succes());
            Assert.Equal("ab123", match.RemainingText());

            match = digits.Match("ab"); // true / "ab"
            Assert.True(match.Succes());
            Assert.Equal("ab", match.RemainingText());
                

        }
    }
}