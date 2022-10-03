namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range(start: '0', end: '9');
            var digits = new OneOrMore(digit);
            var integer = new Sequence(new Optional(new Character('-')), new Choice(new Character('0'), digits));
            var fractional = new Sequence(new Any("."), new OneOrMore(digits));
            var exponential = new Sequence(new Any("eE"), new Optional(new Any("-+")), new OneOrMore(digits));
            pattern = new Sequence(integer, new Optional(fractional), new Optional(exponential));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
