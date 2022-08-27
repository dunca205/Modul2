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
            input = input.ToLower();
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

        private static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }

            return string.Empty;
        }

        private static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > -1 && exponentIndex > -1 && exponentIndex > dotIndex)
            {
                return input.Substring(dotIndex, exponentIndex - dotIndex); // extrage pana la e
            }

            if (dotIndex != -1)
            {
                return input.Substring(dotIndex, input.Length - dotIndex);
            }

            return string.Empty;
        }

        private static string Exponent(string input, int dotIndex, int exponentIndex)
        {
            if (exponentIndex != -1)
            {
                return input.Substring(exponentIndex, input.Length - exponentIndex);
            }

            return string.Empty;
        }

        private static bool CanBeInteger(string integer)
            {
            if (integer == string.Empty)
            {
                return true;
            }

            if (integer.Contains('-'))
            {
                if (integer.StartsWith('-') && (CharacterCount(integer, '-') == 1))
                {
                    return CanBeInteger(integer.Substring(1, integer.Length - 1));
                }

                return false;
            }

            if (integer.StartsWith('0') && integer.Length > 1)
            {
                return false;
            }

            return IsInputNumber(integer);
        }

        private static bool IsValidNumber(string input)
        {
            var dotIndex = input.IndexOf('.');
            var exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });

            return CanBeFractional(Fraction(input, dotIndex, exponentIndex))
            && CanBeExponential(Exponent(input, dotIndex, exponentIndex))
            && CanBeInteger(Integer(input, dotIndex, exponentIndex));
        }

        private static bool CanBeExponential(string exponent)
            {
            if (CharacterCount(exponent, 'e') > 1)
            {
                return false;
            }

            if (exponent == string.Empty)
            {
                return true;
            }

            exponent = exponent[1..];
            if (exponent.StartsWith('+') || exponent.StartsWith('-'))
            {
                return IsInputNumber(exponent[1..]);
            }

            return IsInputNumber(exponent);
        }

        private static bool CanBeFractional(string input)
        {
            if (CharacterCount(input, '.') > 1)
            {
                return false;
            }

            return input != "" ? IsInputNumber(input.Substring(1, input.Length - 1)) : true;
        }

        private static bool IsInputNumber(string input)
        {
            foreach (char character in input)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}
