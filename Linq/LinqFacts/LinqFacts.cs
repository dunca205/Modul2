global using Xunit;
namespace LinqExercise
{
    public class LinqFacts
    {
        [Fact]
        public void CountVowels()
        {
            var vowels = new Linq("aeiouAEIOU");

            Assert.Equal((10, 0), vowels.VowelsAndConsonantsCount());
        }

        [Fact]
        public void CountConsonants()
        {
            var consonants = new Linq("crstn");
            Assert.Equal((0, 5), consonants.VowelsAndConsonantsCount());
        }

        [Fact]
        public void CountVowelsAndConsonats()
        {
            var words = new Linq("Ana are mere");
            Assert.Equal((6, 4), words.VowelsAndConsonantsCount());
        }


        [Fact]
        public void FindFirstNonRepetableLetter()
        {
            var words = new Linq("ana are mere");
            Assert.Equal('n', words.FirstNonRepetableCharacter());
        }

        //[Fact]
        //public void FindFirstNonRepetableLetter_WhenNoCharMeetsTheCondition()
        //{
        //    var words = new Linq("aa ae mmee");
        //    Assert.Equal('\0', words.FirstNonRepetableCharacter());
        //}
        [Fact]
        public void FindMostRepeatedCharacter()
        {
            var words = new Linq("ana are meree");
            Assert.Equal('e', words.MostRepetedCharacter());
            Assert.False(words.MostRepetedCharacter() == ('a'));
        }


    }
}