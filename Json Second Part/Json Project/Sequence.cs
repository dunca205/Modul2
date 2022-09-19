namespace Json
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] pattern)
        {
            patterns = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccesMatch(text);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (!match.Succes())
                {
                    return new FailedMatch(text);
                }
            }

            return match;
        }
    }
}
