namespace Json
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any("  \n\r\t"));
            var value = new Choice(new JsonString(), new Number(), new Text("true"), new Text("false"), new Text("null"));
            var comma = new Character(',');
            var element = new Sequence(ws, value, ws);
            var elements = new List(element: element, separator: comma);
            var member = new Sequence(ws, new JsonString(), ws, new Character(':'), element);
            var members = new List(element: member, separator: comma);

            var array = new Sequence(
                new Character('['),
                new Choice(
                    ws,
                    elements),
                new Character(']'));

            var obj = new Sequence(
                new Character('{'),
                new Choice(
                   ws,
                   members),
                new Character('}'));

            value.Add(array);
            value.Add(obj);

            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
