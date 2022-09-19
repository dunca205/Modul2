namespace Json
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length < prefix.Length)
            {
                return new FailedMatch(text);
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] != text[i])
                {
                    return new FailedMatch(text);
                }
            }

            return new SuccesMatch(text[prefix.Length..]);
        }
    }
}
