namespace Json
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccesMatch(text);

            if (string.IsNullOrEmpty(text))
            {
                return new SuccesMatch(text);
            }

            while (match.Succes())
            {
                match = pattern.Match(match.RemainingText());
            }

            return new SuccesMatch(match.RemainingText());
        }
    }
}
