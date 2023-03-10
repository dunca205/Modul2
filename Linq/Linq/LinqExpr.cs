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
            int vowels = 0;
            int consonants = 0;
            (vowels, consonants) = this.word.ToLower().Where(x => char.IsLetter(x)).
            Aggregate((0, 0), (_, character)
            => "aeiou".Contains(character) ?
            (++vowels, consonants) :
            (vowels, ++consonants));
            return (vowels, consonants);
        }

        public char FirstNonRepetableCharacter()
        {
            var nonRepetableChar = this.word.GroupBy(character => character).
                 First(group => group.Count() == 1);

            return nonRepetableChar.Key;
        }

        public char MostRepetedCharacter()
        {
            var chars = word.GroupBy(character => character).
                MaxBy(occurrence => occurrence.Count());
            return chars.Key;
        }
    }
}