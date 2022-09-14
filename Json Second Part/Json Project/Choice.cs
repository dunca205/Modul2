using System;

namespace Json
{
    public class Choice : IPattern
    {
        private readonly IMatch[] pattern;

        public Choice(params IMatch[] patterns)
        {
            this.pattern = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pat in pattern)
            {
                if (pat.Succes(text))
                {
                    return new SuccesMatch(text);
                }
            }

            return new FailedMatch(text);
        }
    }
}