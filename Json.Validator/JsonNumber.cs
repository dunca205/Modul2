namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return HasValue(input) && IsValidNumber(input);
        }

        private static bool HasValue(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static int CharacterCount(string input, char character)
        {
            int counchar = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(character))
                {
                    counchar++;
                }
            }

            return counchar;
        }

        private static bool IsInteger(string input)
        {
            if (input.Contains('-'))
            {
                if (input.StartsWith('-') || (CharacterCount(input, '-') == 1))
                {
                    return IsInteger(input.Substring(1, input.Length - 1));
                }

                return false;
            }

            if (input.StartsWith('0') && input.Length > 1)
            {
                return false;
            }

            if (input == "0")
            {
                return true;
            }

            return IsInputNumber(input);
        }

        private static bool IsValidNumber(string input)
        {
            input = input.ToLower();

            if (input.Contains('.') && !input.Contains('e'))
            {
                if ((input.StartsWith('.') || input.EndsWith('.')) || (CharacterCount(input, '.') > 1))
                {
                    return false;
                }

                return CanBeFractional(input);
            }

            if (input.Contains('e'))
            {
                if (input.StartsWith('e') || input.EndsWith('e') || (CharacterCount(input, 'e') > 1))
                {
                    return false;
                }

                return CanBeExponential(input);
            }

            return IsInteger(input);
        }

        private static bool CanBeExponential(string input)
        {
            string[] subs = input.Split('e');
            bool validFirstPart = false;
            bool validSecondPart = IsInputNumber(subs[1]);
            if (subs[0].Contains('.'))
            {
                validFirstPart = CanBeFractional(subs[0]);
                return validFirstPart && IsValidNumber(subs[1]);
            }

            if (!subs[0].StartsWith('0'))
            {
                validFirstPart = IsInputNumber(subs[0]);
            }

            if (subs[0].StartsWith('-'))
            {
                validFirstPart = CanBeExponential(subs[0].Substring(1, subs[0].Length - 1));
            }

            if ((subs[1].StartsWith('+') || subs[1].StartsWith('-')) && subs[1].Length > 1)
            {
                validSecondPart = IsInputNumber(subs[1].Substring(1, subs.Length - 1));
            }

            return validFirstPart && validSecondPart;
        }

        private static bool CanBeFractional(string input)
        {
            string[] subs = input.Split('.');
            bool validFirstPart = false;
            bool validSecondPart = false;

            if (subs[0].StartsWith('0') && subs[0].Length == 1)
            {
                validFirstPart = true;
            }

            if (!subs[0].StartsWith('0'))
            {
                validFirstPart = IsInputNumber(subs[0]);
            }

            if (subs[1].Length > 0 && (!subs[1].EndsWith('0')))
            {
                validSecondPart = IsInputNumber(subs[1]);
            }

            return validFirstPart && validSecondPart;
        }

        private static bool IsInputNumber(string input)
        {
            const string Digits = "0123456789";
            for (int i = 0; i < input.Length; i++)
            {
                if (!Digits.Contains(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
