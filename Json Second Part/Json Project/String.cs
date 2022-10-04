namespace Json
{
    public class JsonString : IPattern
    {
        private readonly IPattern pattern;

        public JsonString()
        {
            var hexCharacters = new Choice(
                new Range(start: '0', end: '9'),
                new Range(start: 'a', end: 'f'),
                new Range(start: 'A', end: 'F'));

            var unicode = new Sequence(
                new Character('u'),
                new Sequence(hexCharacters, hexCharacters, hexCharacters, hexCharacters));

            var escapeCharacters = new Any("/bfnrt\"\\/");

            var escapeSequence = new Sequence(
                new Character('\\'),
                new Choice(unicode, escapeCharacters));

            var character = new Choice(
                escapeSequence,
                new Choice(
                new Range(start: ' ', end: '!'),
                new Range(start: '#', end: '['),
                new Range(start: ']', end: char.MaxValue)));

            pattern = new Sequence(new Character('"'), new Many(character), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
