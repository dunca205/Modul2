using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            bool inputCheck = HasContent(input) && IsDoubleQuoted(input) && (!ContainsControlCharacters(input));
            return HasContent(input) && IsDoubleQuoted(input) && !ContainsControlCharacters(input);
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

        private static bool ContainsControlCharacters(string input)
        {
            char[] escapeChars = { '\b', '\f', '\n', '\r', '\t', '\"', '\\', '/' };
            char[] chars = { 'b', 'f', 'n', 'r', 't', '"', '/' };
            string[] escapeChar = { "\b", "\f", "\f", "\r", "\t", "\"", "\\", "\\/" }; // trece cele mai multe teste
            string[] escapeCharu = { "\u0022", "\u005C", "\u002F", "\u0008", "\u000C", "\u000A", "\u000D", "\u0009" };
            string[] escapeCharU = { "U+0022", "U+005C", "U+002F", "U+0008", "U+000C", "U+000A", "U+000D", "U+0009" };

            bool contains = false;
            for (int i = 1; i < input.Length; i++)
            {
                for (int j = 0; j < escapeChar.Length; j++)
                {
                    if (input[i].Equals(escapeChar[j]))
                    {
                        contains = true;
                        return contains;
                    }
                }
            }

            return contains;
        }
    }
}
