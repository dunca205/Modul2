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
            return !string.IsNullOrEmpty(text) &&
                  acceptedCharacters.Contains(text[0]) ?
                  new SuccesMatch(text[1..]) :
                  new FailedMatch(text);
        }
    }
}
