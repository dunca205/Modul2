using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace LinqExercise
{
    public class Linq
    {
        private string word;
        public Linq(string word)
        {
            this.word = word;
        }

        public int VowelsCount()
        {
            return word.ToLower().Count(character => "aeiou".Contains(character));
        }

        public int ConsonatCount()
        {
            int letters = word.ToLower().Count(character => char.IsLetter(character));
            return letters - VowelsCount();
        }
        public char FirstNonRepetableCharacter()
        {
            var rezult = word.ToArray().First(character => !word[word.IndexOf(character)..].Contains(character));
            return rezult;

        }
    }
}