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

        public (int,int) VowelsAndConsonantsCount()
        {
            //int letters = word.ToLower().Count(character => char.IsLetter(character));
            //int vowels = word.ToLower().Count(character => "aeiou".Contains(character));
            //return (vowels, letters - vowels);
            var letters = word.ToLower().Where(character => char.IsLetter(character)).
                Select(letter => "aeiou".Contains(letter));
            

            return (letters.Count(elements => elements == true), letters.Count(elements => elements == false));

        }

        public char FirstNonRepetableCharacter()
        {
            var rezult = word.First();
            return rezult;

        }
    }
}