﻿namespace LinqExercise
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
            return Enumerable.Range(0, word.Length).
             SelectMany((start, index) => Enumerable.Range(index + 1, word.Length - start).
             Select(end => word[start..end])
            .Where(IsPalindrom));

            bool IsPalindrom(IEnumerable<char> sequence)
            {
                return sequence.SequenceEqual(sequence.Reverse());
            }
        }

        public static IEnumerable<IEnumerable<int>> SumGenerator(int[] numbers, int max)

           => Enumerable.Range(0, numbers.Length).
                         SelectMany(start => Enumerable.Range(start, numbers.Length - start).
                         Select(end => numbers.Take(end + 1).Skip(start))).
                         Where(numbers => numbers.Sum() <= max);

        public static IEnumerable<IEnumerable<int>> CombinationsGenerator(int n, int max)
        {
            var seed = new[] { "" };
            return Enumerable.Range(1, n).
                Aggregate(seed, (expresion, _) => expresion.SelectMany(character => new[] { character + '+', character + '-' }).ToArray()).
                Select(Transform).Where(numbers => numbers.Sum() == max);

            IEnumerable<int> Transform(string input)
                => input.Select((sign, index) => sign == '+' ? index + 1 : -(index + 1));
        }

        public static IEnumerable<string> TopWordsBasedOnOccurance(string text, int top)
        {
            var separator = new[] { ' ', '”', '\'', '?', ',', ';', ':', '.', '!' };

            return text.ToLower().Split(separator).GroupBy(word => word).
                OrderByDescending(words => words.Count()).
                Select(group => group.Key).Take(top);
        }
    }
}