using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
           return
                HasContent(input) && IsDoubleQuoted(input);
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static bool IsDoubleQuoted(string input)
        {
            const int minimumLengthRequired = 2;
            return input.Length >= minimumLengthRequired && input[0] == '"' && input[^1] == '"';
        }
}
}
