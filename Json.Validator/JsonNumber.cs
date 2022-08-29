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
                return input[0..dotIndex];
            }

            if (exponentIndex != -1)
            {
                return input[0..exponentIndex];
            }

            return input;
        }

        private static string Fraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex != -1)
            {
                return input[dotIndex..];
            }

           /* if (dotIndex != -1 && exponentIndex != -1 && dotIndex < exponentIndex)
                // daca nu pun aceasta conditie .. in cazul "22e3.3" .. imi da eroare pt ca nu poate sa exteaga de la punct la exponent in sens invers 
                // iar cand se verifica exponentul va da fals pt ca dupa exponentul nu este valid 
            {
                return input[dotIndex..exponentIndex];
            }*/

            return string.Empty;
        }

        private static string Exponent(string input, int dotIndex, int exponentIndex)
        {
            if (exponentIndex != -1)
            {
                input = input[exponentIndex..input.Length];
                return input;
            }

            return string.Empty;
        }

        private static bool CanBeInteger(string integer)
        {
            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
                return CanBeInteger(integer);
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
            var exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            if (exponentIndex != -1)
            {
                input = input[0..exponentIndex];
            }

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