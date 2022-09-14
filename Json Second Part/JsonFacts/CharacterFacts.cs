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
    }
}