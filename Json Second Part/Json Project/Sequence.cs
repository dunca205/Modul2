using System;

namespace Json
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] pattern;

        public Sequence(params IPattern[] patterns)
    {
            pattern = patterns;
    }

        public IMatch Match(string text)
        {
            var newText = text;
            foreach (var pat in pattern)
            {
                IMatch isMatch = pat.Match(newText);
                if (!isMatch.Succes())
                {
                    return new FailedMatch(text);
                }

                newText = isMatch.RemainingText();
            }

            return new SuccesMatch(newText);
        }
    }
}
