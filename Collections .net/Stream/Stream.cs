using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace StreamNamespace
{
    public class StreamClass
    {
        static void Main(string[] args)
        {
            const string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string name = "Cristina";
            var memorystream = new MemoryStream();
            StreamWrite(memorystream, name, true, false);
            StreamRead(memorystream, true, false);
        }
        public static void StreamRead(Stream stream, bool decrypt, bool decompress) // decrypt/decompress
        {
            StreamReader reader = new StreamReader(stream); // am deshis stremul 
            reader.ReadToEnd();

            if (decrypt)
            {
                using (DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider()) // Initializare obiect (DES)  Data Encryption Standard algorithm simetric
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH"); // max 56-bit
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    using (MemoryStream decrypted = new MemoryStream())
                    {
                        stream.Position = 0;
                        using (CryptoStream decryptor = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            int data;
                            while ((data = decryptor.ReadByte()) != -1)
                            {
                                decrypted.WriteByte((byte)data);
                            }
                        }

                        Console.WriteLine(ConvertByteArrayToString(decrypted.GetBuffer()) + " : is the Decrypted text ");
                    }
                }
            }


            if (decompress)
            {

            }

        }

        public static void StreamWrite(Stream stream, string text, bool encrypt, bool compress) // encrypt/ compress
        {
            Console.WriteLine("textlenght is {0} char" , text.Length);
            byte[] byteArray = Encoding.ASCII.GetBytes(text);


            if (compress)
            {
                Console.WriteLine(byteArray.Length + " ByteArray before compression");
                using (MemoryStream compressed = new MemoryStream())
                {
                    using (GZipStream compressor = new GZipStream(compressed, CompressionMode.Compress, leaveOpen: true))
                    {
                        compressor.Write(byteArray);
                    }
                    compressed.Position = 0;
                    byteArray = compressed.ToArray();
                }

                Console.WriteLine("compressed text is : " + ConvertByteArrayToString(byteArray));
                Console.WriteLine(byteArray.Length + " Byte Array after compression");
            }

            if (encrypt)
            {
                using (DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider())
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    using (MemoryStream encrypted = new MemoryStream())
                    {
                        using (CryptoStream encryptor = new CryptoStream(encrypted, cryptic.CreateEncryptor(), CryptoStreamMode.Write, leaveOpen: true)) // criptare 
                        {
                            encryptor.Write(byteArray);
                        }

                        encrypted.Position = 0;
                        byteArray = encrypted.ToArray();
                    }
                }

                Console.WriteLine(byteArray.Length + " bytearray length after encryption");
                Console.WriteLine("Encrypted text is : " + ConvertByteArrayToString(byteArray));
            }

            stream.Write(byteArray, 0, byteArray.Length); // fara using pt ca vreau sa ramana deschis sa citim de pe el
            Console.WriteLine(stream.Length + " stream length after the byteArray was written to the stream");

        }
        public static string ConvertByteArrayToString(byte[] byteArray)
        {
            return (Encoding.ASCII.GetString(byteArray));
        }
    }
}


