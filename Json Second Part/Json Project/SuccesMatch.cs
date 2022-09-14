using System;

namespace Json
{
    public class SuccesMatch : IMatch
    {
        private readonly string text;

        public SuccesMatch(string text)
        {
            this.text = text;
        }

        public bool Succes(string text)
        {
            return true;
        }

        public string RemainingText(string text)
        {
            return text;
        }
    }
}
