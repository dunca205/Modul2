global using Xunit;
namespace LinqExercise
{
    public class LinqFacts
    {
        [Fact]
        public void CountVowels()
        {

            Assert.Equal((10, 0), Linq.VowelsAndConsonantsCount("aeiouAEIOU"));
        }

        [Fact]
        public void CountConsonants()
        {
            Assert.Equal((0, 5), Linq.VowelsAndConsonantsCount("crstn"));
        }

        [Fact]
        public void CountVowelsAndConsonats()
        {
            Assert.Equal((6, 4), Linq.VowelsAndConsonantsCount("Ana are mere"));
        }


        [Fact]
        public void FindFirstNonRepetableLetter()
        {
            Assert.Equal('n', Linq.FirstNonRepetableCharacter("ana are mere"));
        }

        [Fact]
        public void FindMostRepeatedCharacter()
        {
            Assert.Equal('e', Linq.MostRepetedCharacter("ana are meree"));
            Assert.False(Linq.MostRepetedCharacter("ana are meree") == ('a'));
        }

        [Fact]
        public void ConversionFromStringToInt()
        {
            Assert.Equal(1234, Linq.ConversionFromStringToInteger("1234"));
        }

        [Fact]
        public void ConversionFromWordToPhoneNumber()
        {
            Assert.Equal(747999852, Linq.ConversionFromStringToInteger("747999852"));
        }

        [Fact]
        public void ConversionFromStringToNumberWhenNumberIsSupposeToBeNegative()
        {
            Assert.Equal(-100, Linq.ConversionFromStringToInteger("-100"));
        }

    }
}
