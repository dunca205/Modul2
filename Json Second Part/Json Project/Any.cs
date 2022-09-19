namespace Json
{
    public class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                foreach (char character in accepted)
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
