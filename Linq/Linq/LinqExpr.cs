using System.Collections.Concurrent;
using System.Xml.Schema;

namespace LinqExercise
{
    public class Linq
    {
        public static (int, int) VowelsAndConsonantsCount(string word)

           => word.ToLower().Where(x => char.IsLetter(x))
           .Aggregate((vowels: 0, consonants: 0), (count, character) => "aeiou".Contains(character) ? (count.vowels + 1, count.consonants) : (count.vowels, count.consonants + 1));

        public static char FirstNonRepetableCharacter(string word)
           => word.GroupBy(character => character).
            First(group => group.Count() == 1).Key;

        public static char MostRepetedCharacter(string word)
            => word.GroupBy(character => character).
            MaxBy(occurrence => occurrence.Count()).Key;

        public static int ConversionFromStringToInteger(string word)
        {
            bool isNegative = word.StartsWith('-');
            if (isNegative)
            {
                word = word[1..];
            }

            const int multiplier = 10;
            int integer = word.Select(ToDigit).
                         Aggregate((total, number) => total * multiplier + number);

            int ToDigit(char character) => char.IsDigit(character) ?
            character - '0' : throw new OverflowException("Character represents a number less than Int32.MinValue or greater than Int32.MaxValue.");

            return isNegative ? -integer : integer;
        }

        public static IEnumerable<string> PalindromeGenerator(string word)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                var substring = word.Skip(i).ToArray();

                for (int j = 0; j < substring.Length; j++)
                {
                    if (IsPalindrom(substring.SkipLast(j)))
                    {
                        words.Add(new string(substring.SkipLast(j).ToArray()));
                    }
                }
            }

            bool IsPalindrom(IEnumerable<char> sequence) => sequence.SequenceEqual(sequence.Reverse());

            return words;
        }
    }
}