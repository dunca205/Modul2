using System;

namespace Json
{
    public interface IMatch
    {
        public bool Succes(string text);

        public string RemainingText(string text);
    }
}
