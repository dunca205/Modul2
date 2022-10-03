using System;

namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var positiveOrNegativeSign = new OptionalPattern(new Any("-+"));
            var negativeSign = new OptionalPattern(new Character('-'));
            var exponentialSign = new Any("eE");
            var rangeOneNine = new Range(start: '1', end: '9');
            var digit = new Choice(new Character('0'), rangeOneNine); // poate sa fie 0 sau  orice nr de la 1-9
            var digits = new Choice(new Character('0'), new OneOrMore(digit)); // poate sa fie 0 sau un alt nr care nu incepe cu 0 dar poate sa il contina si pe 0
            var integer = new Sequence(negativeSign, digits);
            var fractionalPart = new Sequence(new Any("."), new OneOrMore(digits));
            var exponentialPart = new Sequence(exponentialSign, positiveOrNegativeSign, new OneOrMore(digits));
            pattern = new Sequence(integer, new OptionalPattern(fractionalPart), new OptionalPattern(exponentialPart));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
