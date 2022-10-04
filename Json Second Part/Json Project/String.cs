namespace Json
{
#pragma warning disable CA1720 // Identifier contains type name
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class String : IPattern
#pragma warning restore CA1716 // Identifiers should not match keywords
#pragma warning restore CA1720 // Identifier contains type name
    {
        private readonly IPattern pattern;

        public String()
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
