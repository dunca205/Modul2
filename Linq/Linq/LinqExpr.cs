namespace LinqExercise
{
    public class Linq
    {
        private string word;
        public Linq(string word)
        {
            this.word = word;
        }

        public (int, int) VowelsAndConsonantsCount()
        {
            var letters = word.ToLower().Where(x => char.IsLetter(x));
            var vowelsAndConsonant = (0, 0);
            vowelsAndConsonant = letters.Aggregate((0, 0), (counter, character)
           => "aeiou".Contains(character) ?
           (vowelsAndConsonant.Item1 += 1, vowelsAndConsonant.Item2) :
           (vowelsAndConsonant.Item1, vowelsAndConsonant.Item2 += 1));
            return vowelsAndConsonant;



        }

        public char FirstNonRepetableCharacter()
        {
            var nonRepetableChar = word.GroupBy(character => character).
                 FirstOrDefault(group => group.Count() == 1);

            return nonRepetableChar.Key;
        }
    }
}