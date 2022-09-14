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

        public bool Succes()
        {
            return true;
        }

        public string RemainingText()
        {
            return text;
        }
    }
}
