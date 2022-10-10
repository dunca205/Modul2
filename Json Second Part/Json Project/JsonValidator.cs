namespace Json
{
    public class JsonValidator
    {
        static void Main(string[] args)
        {
            IMatch match;
            foreach (var arg in args)
            {
                string text = System.IO.File.ReadAllText(arg);
                match = new Value().Match(text);
                Console.WriteLine(match.Succes() ? "The text file conforms to the JSON format" : "The text does not conform to the JSON format");
            }
        }
    }
}
