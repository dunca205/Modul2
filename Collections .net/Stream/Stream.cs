using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace StreamNamespace
{
    public class StreamClass
    {
        public static void Read(Stream stream, bool decrypt, bool decompress) // decrypt/decompress
        {
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
                            decryptor.CopyTo(decrypted);
                        }
                        Console.WriteLine("Decrypted text is : {0} ", ConvertByteArrayToString(decrypted.GetBuffer()));
                    }
                }
            }

            if (decompress)
            {
                using (MemoryStream decompressed = new MemoryStream())
                {
                    using (var decompresor = new GZipStream(stream, CompressionMode.Decompress, true))
                    {
                        stream.Position = 0;
                        decompresor.CopyTo(decompressed);
                    }
                    Console.WriteLine("The decompressed length is " + decompressed.Length);
                }
            }

        }

        public static void Write(Stream stream, string text, bool encrypt, bool compress) // encrypt/ compress
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(text);

            if (compress)
            {
                using (MemoryStream compressed = new MemoryStream())
                {
                    using (GZipStream compressor = new GZipStream(compressed, CompressionMode.Compress, leaveOpen: true))
                    {
                        compressor.Write(byteArray); // scrie byteArray ul pe compressor, care il transmite in streamul compressed
                    }
                    compressed.Position = 0;
                    byteArray = compressed.ToArray(); // byteArray -> ia valorile buffer ului din compressed
                }
                Console.WriteLine("compressed text is :\n " + ConvertByteArrayToString(byteArray) + "\nand it s new size is " + byteArray.Length);
            }

            if (encrypt)
            {
                using (var cryptic = new DESCryptoServiceProvider())
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
                //  Console.WriteLine("Encrypted text is : " + ConvertByteArrayToString(byteArray));
            }

            stream.Write(byteArray, 0, byteArray.Length);

        }
        public static string ConvertByteArrayToString(byte[] byteArray)
        {
            return (Encoding.ASCII.GetString(byteArray));
        }
    }
}


