﻿namespace Json
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(prefix) ?
                new SuccesMatch(text[prefix.Length..]) :
                new FailedMatch(text);
        }
    }
}
