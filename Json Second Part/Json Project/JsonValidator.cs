﻿namespace Json
{
    public class JsonValidator
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            foreach (var arg in args)
            {
                string text = System.IO.File.ReadAllText(arg);
                IMatch match = new Value().Match(text);
                if (match.Succes() && match.RemainingText().Equals(string.Empty))
                {
                    Console.WriteLine("The text file conforms to the JSON format");
                }
            }

            Console.WriteLine("Introduce path to text file");

            string path = Console.ReadLine();

            IMatch matchInput = new Value().Match(File.ReadAllText(path));
            if (!matchInput.Succes() || !matchInput.RemainingText().Equals(string.Empty))
            {
                return;
            }

            Console.WriteLine("The text file conforms to the JSON format");
        }
    }
}
