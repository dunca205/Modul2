using System;

namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var sign = new Any("-+");
            var exponentialSign = new Any("eE");
            var integerChoice = new Choice(new OneOrMore(new Range(start: '0', end: '9')));
            var integer = new Sequence(new OptionalPattern(new Character('-')), integerChoice);
            var fractionalPart = new Sequence(new Any("."), new OneOrMore(integerChoice));
            var exponentialPart = new Sequence(exponentialSign, new OptionalPattern(sign), new OneOrMore(new Range(start: '0', end: '9')));
            pattern = new Sequence(integer, new OptionalPattern(fractionalPart), new OptionalPattern(exponentialPart));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
