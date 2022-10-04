namespace Json
{
    public class JsonString : IPattern
    {
        private readonly IPattern pattern;

        public JsonString()
        {
            var codePoint = new Choice(new Range(start: '\u0020', end: '\u0021'), new Range(start: '\u0023', end: '\u005B'), new Range(start: '\u005D', end: char.MaxValue));

            var hexCharacters = new Choice(new Range(start: '0', end: '9'), new Range(start: 'a', end: 'f'), new Range(start: 'A', end: 'F'));
            var unicode = new Sequence(new Character('u'), new Sequence(hexCharacters, hexCharacters, hexCharacters, hexCharacters));

            var escapeCharacters = new Any("/bfnrt\"\\/");

            var escapeSequence = new Sequence(new Character('\\'), new Choice(unicode, escapeCharacters));
            var character = new Choice(escapeSequence, codePoint);

            pattern = new Sequence(new Character('"'), new Many(character), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
