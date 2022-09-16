namespace Json
{
    public class FailedMatch : IMatch
    {
        private readonly string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Succes()
        {
            return false;
        }
    }
}
