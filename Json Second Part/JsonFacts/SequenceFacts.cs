using Xunit;

namespace Json
{
    public class SequenceFacts
    {
        [Fact]
        public void MatchForOneSequence()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            IMatch match = ab.Match("abcd");
            Assert.Equal("cd", match.RemainingText());
            Assert.True(match.Succes());

            match = ab.Match("ax");
            Assert.Equal("ax", match.RemainingText());
            Assert.False(match.Succes());

            match = ab.Match("def"); // false / "def"
            Assert.Equal("def", match.RemainingText());
            Assert.False(match.Succes());
            
            match = ab.Match(""); // false / ""
            Assert.Equal("", match.RemainingText());
            Assert.False(match.Succes());
            
            match = ab.Match(null); // false / null
            Assert.Equal(null, match.RemainingText());
            Assert.False(match.Succes());
        }
        [Fact]
        public void MatchForTwoSequences()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));

            IMatch match = abc.Match("abcd");
            Assert.True(match.Succes());
            Assert.Equal("d", match.RemainingText());

            match = abc.Match("def"); // false / "def"
            Assert.False(match.Succes());
            Assert.Equal("def", match.RemainingText());
            
            match = abc.Match("abx"); // false / "abx"
            Assert.False(match.Succes());
            Assert.Equal("abx", match.RemainingText());

            match = abc.Match(""); // false / ""
            Assert.False(match.Succes());
            Assert.Equal("", match.RemainingText());

             match = abc.Match(null); // false / null
             Assert.Equal(null, match.RemainingText());
             Assert.False(match.Succes());
        }
        [Fact]
        public void MatchSequenceForHex()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'),new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            IMatch match = hexSeq.Match("u1234");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
            
            match = hexSeq.Match("uabcdef"); // true / "ef"
            Assert.True(match.Succes());
            Assert.Equal("ef", match.RemainingText());

            match = hexSeq.Match("uB005 ab"); // true / " ab"
            Assert.True(match.Succes());
            Assert.Equal(" ab", match.RemainingText());
            
            match = hexSeq.Match("abc"); // false / "abc"
            Assert.False(match.Succes());
            Assert.Equal("abc", match.RemainingText());
            
            match = hexSeq.Match(null); // false / null
            Assert.Equal(null, match.RemainingText());
            Assert.False(match.Succes());


        }
    }
}