namespace Json
{
    public class Any : IPattern
    {
        private readonly string acceptedCharacters;

        public Any(string accepted)
        {
            this.acceptedCharacters = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            if (acceptedCharacters.Contains(text[0]))
            {
                return new SuccesMatch(text[1..]);
            }

            return new FailedMatch(text);
        }
    }
}
