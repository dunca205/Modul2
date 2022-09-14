namespace Json
{
    public class CharacterFacts
    {
        [Fact]
        public void CharacterIsMatch()
        {
            var character = new Character('0');
            IMatch match = character.Match("012");
            Assert.True(match.Succes());
            Assert.Equal("12", match.RemainingText());
        }
        [Fact]
        public void CharacterIsNotMatch()
        {
            var character = new Character('0');
            IMatch match = character.Match("112");
            Assert.False(match.Succes());
            Assert.Equal("112", match.RemainingText());
        }
    }
}