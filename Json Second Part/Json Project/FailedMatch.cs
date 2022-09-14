using System;

namespace Json
{
    public class FailedMatch : IMatch
    {
        private readonly string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText(string text)
        {
            return text;
        }

        public bool Succes(string text)
        {
            return false;
        }
    }
}
