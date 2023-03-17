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

        [Fact]
        public void ThrowExceptionWhenNotAllCharactersAreDigits()
        {
            Assert.Throws<OverflowException>(() => Linq.ConversionFromStringToInteger("ana123"));
        }

        [Fact]
        public void GeneratePalindrome()
        {
            var rezult = Linq.PalindromeGenerator("aabaac");
            var expectedResult= new[] { "aabaa", "aa", "a", "aba", "a", "b", "aa", "a", "a", "c" };          
            Assert.Equal(expectedResult, rezult);
        }

        [Fact] 
        public void GeneratePalindromeWhenAllLettersAreDistinct()
        {
            var rezult = Linq.PalindromeGenerator("abc");
            var expectedResult = new[] { "a", "b", "c" };
            Assert.Equal(expectedResult, rezult);
        }
        

    }
}
