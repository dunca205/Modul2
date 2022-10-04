namespace Json
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class Optional : IPattern
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
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
