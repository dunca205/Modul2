using System.Xml.Schema;

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
            //int vow = 0;
            //int cons = 0;
            //word = word.ToLower();
            //for (int i = 0; i < word.Length; i++)
            //{
            //    if (char.IsLetter(word[i]))
            //    {
            //        if ("aeiou".Contains(word[i]))
            //        {
            //            vow++;
            //        }
            //        else
            //        {
            //            cons++;
            //        }
            //    }

            //}
            int vow = 0;
            int cons = 0;
            var rez = word.ToLower().Where(x => char.IsLetter(x));
            var re = rez.Aggregate(0,
                (a, b) => char.IsLetter(b) && "aeiou".Contains(b) ? a + 1 : a);
            return (re, cons);
            //"aeiou".Contains(character)
   
        }

        public char FirstNonRepetableCharacter()
            {
                var nonRepetableChar = word.GroupBy(character => character).
                     FirstOrDefault(group => group.Count() == 1);

                return nonRepetableChar.Key;
            }
        }
    }