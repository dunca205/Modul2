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

        private static string Integer(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1)
            {
                input = input[..dotIndex];
                return input;
            }

            if (exponentIndex != -1)
            {
                input = input[..exponentIndex];
                return input;
            }

            return input;
        }

        private static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1 && exponentIndex != -1)
            {
                input = input[dotIndex..exponentIndex];
                return input;
            }

            if (dotIndex != -1)
            {
                input = input[dotIndex..];
                return input;
            }

            return string.Empty;
        }

        private static string Exponent(string input, int exponentIndex)
        {
            if (exponentIndex != -1)
            {
                input = input[exponentIndex..];
                return input;
            }

            return string.Empty;
        }

        private static bool CanBeInteger(string integer)
        {
            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
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

            return CanBeInteger(Integer(input, dotIndex, exponentIndex))
             && CanBeFractional(Fraction(input, dotIndex, exponentIndex))
             && CanBeExponential(Exponent(input, exponentIndex));
        }

        private static bool CanBeExponential(string exponent)
        {
            if (exponent == string.Empty)
            {
                return true;
            }

            exponent = exponent[1..];
            if (exponent.StartsWith('+') || exponent.StartsWith('-'))
            {
                exponent = exponent[1..];
            }

            return IsInputNumber(exponent);
        }

        private static bool CanBeFractional(string input)
        {
            return input == "" || IsInputNumber(input[1..]);
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