namespace LinqExercise
{
    public class Linq
    {
        private readonly string word;

        public Linq(string word)
        {
            this.word = word;
        }

        public (int, int) VowelsAndConsonantsCount()
        {
            var vowelsAndConsonants = (0, 0);
            vowelsAndConsonants = this.word.ToLower().Where(x => char.IsLetter(x)).
            Aggregate((0, 0), (_, character)
            => "aeiou".Contains(character) ?
            (++vowelsAndConsonants.Item1, vowelsAndConsonants.Item2) :
            (vowelsAndConsonants.Item1, ++vowelsAndConsonants.Item2));
            return vowelsAndConsonants;
        }

        public char FirstNonRepetableCharacter()
        {
            var nonRepetableChar = this.word.GroupBy(character => character).
                 First(group => group.Count() == 1);

            return nonRepetableChar.Key;
        }
    }
}