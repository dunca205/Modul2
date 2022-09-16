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
            IMatch match = null;
            foreach (var pattern in patterns)
            {
                if (match != null)
                {
                    match = pattern.Match(match.RemainingText());
                }

                match ??= pattern.Match(text);

                if (!match.Succes())
                {
                    return new FailedMatch(text);
                }
            }

            return match;
        }
    }
}
