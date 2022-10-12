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

            Console.WriteLine("Introduce path to the folder that contains the text files");
            string paths = "";
            while (paths != "stop")
            {
                paths = Console.ReadLine();
                foreach (string path2 in System.IO.Directory.GetFiles(paths))
                {
                    IMatch matchInput = new Value().Match(System.IO.File.ReadAllText(path2));
                    if (matchInput.Succes() && matchInput.RemainingText().Equals(string.Empty))
                    {
                        Console.WriteLine("The text file conforms to the JSON format");
                    }
                }
            }
        }
    }
}
