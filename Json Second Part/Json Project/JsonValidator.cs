namespace Json
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
        }
    }
}
