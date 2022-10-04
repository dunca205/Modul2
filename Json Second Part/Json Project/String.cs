using System;

namespace Json
{
    public class StringJson : IPattern
    {
        private readonly IPattern pattern;

        public StringJson()
        {
            var hexCharacters = new Any("0123456789abcdefABCDEF");
            var escapeSequenceCharacters = new Any("/bfnrt\"\\/");
            var unicode = new Sequence(new Character('u'), new Sequence(hexCharacters, hexCharacters, hexCharacters, hexCharacters));
            var validChar = new Range(start: ' ', end: char.MaxValue);
            var specialCharacter = new Sequence(new Character('\\'), new Choice(unicode, escapeSequenceCharacters));
            pattern = new Sequence(new Character('"'), new Choice(specialCharacter, validChar), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
