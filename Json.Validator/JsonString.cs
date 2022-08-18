using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && IsValidJsonString(input);
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

        private static bool IsValidJsonString(string input)
        {
            string unquotedInputData = input[1..^1];
            int currentIndex = 0;

            while (currentIndex < unquotedInputData.Length)
            {
                int incrementIndex = 1;
                if (!IsControlCharacter(unquotedInputData, currentIndex))
                {
                    return false;
                }

                if (unquotedInputData[currentIndex] == '\\' && (currentIndex == unquotedInputData.Length - 1 || !IsEscapableCharacter(unquotedInputData, currentIndex, ref incrementIndex)))
                {
                    return false;
                }

                currentIndex += incrementIndex;
            }

            return true;
        }

        private static bool IsControlCharacter(string unquotedInputData, int currentIndex)
        {
            const int ControlCharUpperLimit = 31;
            return unquotedInputData[currentIndex] > Convert.ToChar(ControlCharUpperLimit);
        }

        private static bool IsValidUnicode(string unquotedInputData, int index)
        {
            const int NumberOfHexCharacters = 4;
            string getHex = "";
            int unquoteInputLenght = unquotedInputData.Length - NumberOfHexCharacters;
            if (unquoteInputLenght < NumberOfHexCharacters)
            {
                return false;
            }

            for (int i = index; i < index + NumberOfHexCharacters; i++)
            {
                if (IsValidHEXValue(unquotedInputData[i]))
                {
                    getHex = getHex + unquotedInputData[i];
                }
            }

            return getHex.Length == NumberOfHexCharacters;
        }

        private static bool IsEscapableCharacter(string unquotedInputData, int currentIndex,  ref int incrementIndex)
        {
            const string EscapableCharacters = "\"\\/bfnrt";
            const int HexLength = 4;
            incrementIndex = 1;
            int nextCharacter = currentIndex + incrementIndex;

            if (unquotedInputData[nextCharacter] == 'u' && unquotedInputData.Length > currentIndex + HexLength)
            {
                const int Pass2Positions = 2;
                return IsValidUnicode(unquotedInputData, currentIndex + Pass2Positions);
            }

            incrementIndex++;
            return EscapableCharacters.Contains(unquotedInputData[nextCharacter]);
        }

        private static bool IsValidHEXValue(char currentCharacter)
        {
            const string HexCharacters = "0123456789abcdef";
            return HexCharacters.Contains(char.ToLower(currentCharacter));
        }
    }
}
