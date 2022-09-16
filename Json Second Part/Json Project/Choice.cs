namespace Json
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] pattern)
        {
            this.patterns = pattern;
        }

        public IMatch Match(string text)
        {
            foreach (var patern in patterns)
            {
                IMatch match = patern.Match(text);
                if (match.Succes())
                {
                    return match;
                }
            }

            return new FailedMatch(text);
        }
    }
}