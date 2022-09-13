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

        public bool Match(string text)
        {
            return pattern.Any(x => x.Match(text));
        }
    }
}