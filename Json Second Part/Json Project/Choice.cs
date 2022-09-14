using System;

namespace Json
{
    public class Choice : IPattern
    {
        private readonly IPattern[] pattern;

        public Choice(params IPattern[] patterns)
        {
            this.pattern = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pat in pattern)
            {
                IMatch match = pat.Match(text);
                if (match.Succes())
                {
                    return new SuccesMatch(match.RemainingText());
                }
            }

            return new FailedMatch(text);
        }
    }
}