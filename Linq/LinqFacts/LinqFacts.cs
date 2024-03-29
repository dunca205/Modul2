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
            var expectedResult = new[] { "a", "aa", "aabaa", "a", "aba", "b", "a", "aa", "a", "c" };
            Assert.Equal(expectedResult, rezult);
        }

        [Fact]
        public void GeneratePalindromeWhenAllLettersAreDistinct()
        {
            var rezult = Linq.PalindromeGenerator("abc");
            var expectedResult = new[] { "a", "b", "c" };
            Assert.Equal(expectedResult, rezult);
        }


        [Fact]
        public void GenerateSumsForFiveConsecutiveNumbers()
        {
            var expected = new[] {
                new[] { 1 }, new[] { 1, 2 },  new[] { 1, 2, 3 },
                new[] { 2 }, new[] { 2, 3 },
                new[] { 3 }, new[] { 3, 4 },
                new[] { 4 },
                new[] { 5 }};

            Assert.Equal(expected, Linq.SumGenerator(new[] { 1, 2, 3, 4, 5 }, 7));
        }

        [Fact]
        public void GenerateSumsWhenNegativeNumbersArePresent()
        {
            var expected = new[] {
                new[] { 1 }, new[] { 1, 2 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, -5 },
                new[] { 2 }, new[] { 2, 3 }, new[] { 2, 3, 4, -5},
                new[] { 3 }, new[] { 3, 4 }, new[] { 3, 4, -5},
                new[] { 4 }, new[] { 4, -5},
                new[] {-5 }};
            Assert.Equal(expected, Linq.SumGenerator(new[] { 1, 2, 3, 4, -5 }, 7));

        }

        [Fact]
        public void GenerateAllCombination()
        {
            var expected = new[] { new[] { 1, -2, 3, -4, 5 }, new[] { -1, 2, 3, 4, -5 }, new[] { -1, -2, -3, 4, 5 } };
            Assert.Equal(expected, Linq.CombinationsGenerator(5, 3));
        }

        [Fact]
        public void GetTopMostRepetedWordsInAText()
        {
            var expected = new[] { "ana", "are", "mere", "pere", "mure" };
            Assert.Equal(expected, Linq.TopWordsBasedOnOccurance("ana are mere ana are pere ana are mure ana", 5));
        }

        [Fact]
        public void GetTopMostRepetedWordsWhenSameNamesAreWrittenWithLowerAndUpperCases()
        {
            var expected = new[] { "ana", "are", "mere", "pere", "mure" };
            Assert.Equal(expected, Linq.TopWordsBasedOnOccurance("Ana are meRe aNa are pere anA aRe mure Ana", 5));
        }

        [Fact]
        public void GetTop3MostRepetedWordsInAText()
        {
            var expected = new[] { "ana", "are", "mere" };
            Assert.Equal(expected, Linq.TopWordsBasedOnOccurance("ana are mere ana are pere ana are mure ana", 3));
        }

        [Fact]
        public void GetTop3MostRepetedWordsInATextWhenWordsAreSeparatedByPunctuationMarks()
        {
            var expected = new[] { "ana", "are", "mere" };
            Assert.Equal(expected, Linq.TopWordsBasedOnOccurance("ana?are!mere'ana:are pere;ana.are mure;ana", 3));
        }

    }
}
