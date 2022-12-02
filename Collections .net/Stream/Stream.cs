namespace Stream
{
    public class Stream
    {
        static void Main(string[] args)
        {
            string pathToFile = "TextFile.txt";
            StreamWrite(pathToFile);
            StreamRead(pathToFile);
        }
        public static void StreamRead(string pathToFile)
        {
            StreamReader reader = new StreamReader(pathToFile); // crearea unui obiect StreamReader
            while (!reader.EndOfStream) // citeste pana la finalul fisierului cate o linie pe rand
            {
                Console.WriteLine(reader.ReadLine());
            }

            reader.Close();
        }
        public static void StreamWrite(string pathToFile)
        {
            StreamWriter writer = new StreamWriter(pathToFile, true); // cream un obiect StreamWriter -> care permite scriere
            string temp = " ";

            while (temp != null && temp != string.Empty)
            {
                temp = Console.ReadLine();
                writer.WriteLine(temp );
            }

            writer.Close();
        }

        public void GZipStreamCompress()
        {
        }
        public void GZipStreamDecompress()
        {
        }
        public void CryptoStreamEncode()
        {
        }
        public void CryptoStreamDecode()
        {
        }

    }
}