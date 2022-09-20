namespace Json
{
    public class OptionalPattern : IPattern
    {
        private readonly IPattern pattern;

        public OptionalPattern(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = pattern.Match(text);
            return new SuccesMatch(match.RemainingText());
        }
    }
}
