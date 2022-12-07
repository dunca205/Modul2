using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Stream
{
    public class Stream
    {
        static void Main(string[] args)
        {
            string path = "TextFile.txt";
            string text = "Azi este miercuri";
            StreamWrite(path, text, true, true);
            StreamRead(path, true, true);
            long textFileSize = new FileInfo("TextFile.txt").Length;
            long gzipedFileSize = new FileInfo("GzipedFile.gz").Length;

        }
        public static void StreamRead(string filepath, bool decrypt, bool decompress) // decrypt/decompress
        {
            if (decrypt)
            {
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider(); // Initializare obiect (DES)  Data Encryption Standard algorithm simetric
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // max 56-bit
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                FileStream inputStream = new FileStream("EncryptedFile.txt", FileMode.Open); // deschide fisierul de decriptat
                using (CryptoStream decryptor = new CryptoStream(inputStream, cryptic.CreateDecryptor(), CryptoStreamMode.Read)) // decriptare inputStream
                {
                    using FileStream outputStream = File.Open("DecryptedFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    int data;
                    while ((data = decryptor.ReadByte()) != -1) // citieste data = bytes din decryptor si ii 
                    {
                        outputStream.WriteByte((byte)data);
                    }
                    outputStream.Close();
                }

                inputStream.Close();
            }
        
            if (decompress)
            {
                using FileStream compressed = File.Open("GzipedFile.gz", FileMode.Open); // deschide fisierul comprimat 
                using FileStream decompressed = File.Open("UnGzipFile.txt", FileMode.OpenOrCreate); // creaza/deschide un fisier text pt datele decomprimate
                using var decompressor = new GZipStream(compressed, CompressionMode.Decompress); // decomprimarea unui streamFile
                decompressor.CopyTo(decompressed);
            }

            StreamReader inputFile = File.OpenText(filepath);
            while (!inputFile.EndOfStream)
            {
                inputFile.ReadLine();
            }
            inputFile.Close();
        }

        public static void StreamWrite(string filePath, string text, bool encrypt, bool compress) // encrypt/ compress
        {
            StreamWriter outputFile = File.CreateText(filePath);
            outputFile.WriteLine(text);
            outputFile.Close();

            if (encrypt)
            {
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider(); // crearea obiect DES 
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // secret key
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // trebui sa aiba aceasi dimensiune ca si KEY
                FileStream inputStream = new FileStream(filePath, FileMode.Open); // deschide fisierul
                using (FileStream outputStream = File.Open("EncryptedFile.txt", FileMode.OpenOrCreate)) // deschide sau creaza un fisier unde va fi salvata varianta criptata a textului
                {
                    using (CryptoStream encryptor = new CryptoStream(outputStream, cryptic.CreateEncryptor(), CryptoStreamMode.Write)) // criptare 
                    {
                        byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(text); // transforma in byte array textul
                        encryptor.Write(textBytes, 0, textBytes.Length); // se scrie in encryptor stream.. sirul de bytes
                    }
                }

                inputStream.Close();
            }


            if (compress)
            {
                using FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                using FileStream compressed = File.Open("GzipedFile.gz", FileMode.OpenOrCreate, FileAccess.Write);
                using var compressor = new GZipStream(compressed, CompressionMode.Compress);
                inputStream.CopyTo(compressor);
            }
        }
    }
}