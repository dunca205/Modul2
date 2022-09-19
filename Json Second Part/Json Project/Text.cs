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
            return string.IsNullOrEmpty(text) || text.Length < prefix.Length || !text.StartsWith(prefix) ?
                new FailedMatch(text) :
                new SuccesMatch(text[prefix.Length..]);
        }
    }
}
