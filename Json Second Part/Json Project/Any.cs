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
            if (!string.IsNullOrEmpty(text))
            {
                foreach (char character in acceptedCharacters)
                {
                    if (text.StartsWith(character))
                    {
                        return new SuccesMatch(text[1..]);
                    }
                }
            }

            return new FailedMatch(text);
        }
    }
}
