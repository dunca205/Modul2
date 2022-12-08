using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Stream
{
    public class Stream
    {
        private MemoryStream stream;
        public Stream(MemoryStream baseStream)
        {
            stream = baseStream;
        }
        static void Main(string[] args)
        {
            var memorystream = new MemoryStream();
            var newStream = new Stream(memorystream);
            const string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string name = "Cristina";
            newStream.StreamWrite(Message, false, true);
            newStream.StreamRead(false, true);
        }
        public void StreamRead(bool decrypt, bool decompress) // decrypt/decompress
        {
            /*if (decrypt)
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
            }*/

            if (decompress)
            {
                using (MemoryStream decompressed = new MemoryStream())
                {
                    using var gZipStream = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true);
                    {
                        gZipStream.CopyTo(decompressed);
                    }
                    stream.SetLength(0);
                    decompressed.Position = 0;
                    decompressed.WriteTo(stream);

                }
                Console.WriteLine(stream.Length);

                StreamReader read = new StreamReader(stream);
                {
                    stream.Position = 0;
                    read.ReadToEnd();
                    stream.Position = 0;
                    string text = read.ReadToEnd();
                    Console.WriteLine(text.Length);
                }

            }
        }
        public void StreamWrite(string text, bool encrypt, bool compress) // encrypt/ compress
        {
            using (StreamWriter writeStream = new StreamWriter(stream, leaveOpen: true))
            {
                writeStream.Write(text);// dupa scriere, stream va avea 445 byes
            }

            if (compress)
            {
                Console.WriteLine(stream.Length + " before compression");
                using (MemoryStream compressed = new MemoryStream())
                {
                    using (GZipStream compressor = new GZipStream(compressed, CompressionMode.Compress, leaveOpen: true))
                    {
                        stream.Position = 0;
                        stream.WriteTo(compressor);
                    }

                    compressed.Position = 0;
                    stream.SetLength(0);
                    compressed.WriteTo(stream);
                    compressed.Close();
                }
                Console.WriteLine(Convert.ToBase64String(stream.ToArray()));
                Console.WriteLine(stream.Length + " after compression");
            }

            if (encrypt)
            {
                using (DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider())  // crearea obiect DES 
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // secret key
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // trebui sa aiba aceasi dimensiune ca si KEY
                    using (MemoryStream encrypted = new MemoryStream())
                    {
                        using (CryptoStream encryptor = new CryptoStream(encrypted, cryptic.CreateEncryptor(), CryptoStreamMode.Write, leaveOpen: true)) // criptare 
                        {
                            stream.Position = 0;
                            stream.WriteTo(encryptor);
                        }

                        stream.SetLength(0);
                        encrypted.Position = 0;
                        encrypted.WriteTo(stream);
                    }

                    Console.WriteLine("length after encrypt is " + stream.Length + " ||  encrypted text is :");
                    Console.WriteLine(Convert.ToBase64String(stream.ToArray()));
                }
            }

        }
    }
}

