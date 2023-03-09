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
            var vowelsAndConsonant = (0, 0);
            vowelsAndConsonant = this.word.ToLower().Where(x => char.IsLetter(x)).
            Aggregate((0, 0), (_, character)
            => "aeiou".Contains(character) ?
            (++vowelsAndConsonant.Item1, vowelsAndConsonant.Item2) :
            (vowelsAndConsonant.Item1, ++vowelsAndConsonant.Item2));
            return vowelsAndConsonant;
        }

        public char FirstNonRepetableCharacter()
        {
            var nonRepetableChar = this.word.GroupBy(character => character).
                 First(group => group.Count() == 1);

            return nonRepetableChar.Key;
        }
    }
}