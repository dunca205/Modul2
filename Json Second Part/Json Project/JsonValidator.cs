using System;

namespace Json
{
    public class JsonValidator
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\sorin\Desktop\JsonExample1.txt");
            IMatch match = new Value().Match(text);
            Console.WriteLine(match.Succes() ? "The text file conforms to the JSON format" : "The text does not conform to the JSON format");
        }
    }
}
