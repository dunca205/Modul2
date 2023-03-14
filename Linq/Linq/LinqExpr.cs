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
            => word.GroupBy(character => character)
            .MaxBy(occurrence => occurrence.Count()).Key;

        public static int ConversionFromStringToInteger(string word)
        {
            var dictionary = new Dictionary<char, int>();
            dictionary.Add('0', 0);
            dictionary.Add('1', 1);
            dictionary.Add('2', 2);
            dictionary.Add('3', 3);
            dictionary.Add('4', 4);
            dictionary.Add('5', 5);
            dictionary.Add('6', 6);
            dictionary.Add('7', 7);
            dictionary.Add('8', 8);
            dictionary.Add('9', 9);

            var rezult = word.Select(character => dictionary[character]).ToArray();

            return word.Select(character => dictionary[character]).
                       Aggregate(0, (total, number) => total * 10 + number);
        }
    }
}