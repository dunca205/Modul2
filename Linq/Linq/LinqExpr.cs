﻿namespace LinqExercise
{
    public class Linq
    {
        public static (int, int) VowelsAndConsonantsCount(string word)

           => word.ToLower().Where(x => char.IsLetter(x))
           .Aggregate((vowels: 0, consonants: 0), (count, character)
           => "aeiou".Contains(character) ? (count.vowels + 1, count.consonants) : (count.vowels, count.consonants + 1));

        public static char FirstNonRepetableCharacter(string word)
           => word.GroupBy(character => character).
            FirstOrDefault(group => group.Count() == 1)?.Key ?? '\0';

        public static char MostRepetedCharacter(string word)
            => word.GroupBy(character => character).
            MaxBy(occurrence => occurrence.Count()).Key;
    }
}