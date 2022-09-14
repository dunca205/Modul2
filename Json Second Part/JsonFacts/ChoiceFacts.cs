using Xunit;
namespace Json
{
    public class ChoiceFacts
    {

        [Fact]
        public void ChoiceMatchCharacter()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));

            IMatch match = digit.Match("012");
            Assert.True(match.Succes());
            Assert.Equal("2", match.RemainingText());
        }
    }
}