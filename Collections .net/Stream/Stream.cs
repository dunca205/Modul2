using System.IO.Compression;
using System.Security.Cryptography;

namespace StreamNamespace
{
    public class StreamClass
    {
        public static Aes aesAlgorithm = Aes.Create();
        public static string Read(Stream stream, bool decrypt = false, bool decompress = false)
        {
            stream.Seek(0, SeekOrigin.Begin);

            if (decompress)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            if (decrypt)
            {
                stream = new CryptoStream(stream, aesAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);
            }

            StreamReader fromStream = new StreamReader(stream);
            return fromStream.ReadToEnd(); ;
        }

        public static void Write(Stream stream, string text, bool encrypt = false, bool compress = false)
        {
            if (compress)
            {
                stream = new GZipStream(stream, CompressionMode.Compress);
            }

            if (encrypt)
            {
                stream = new CryptoStream(stream, aesAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
            }

            StreamWriter toStream = new StreamWriter(stream);
            toStream.Write(text);
            toStream.Flush();

            if (stream is CryptoStream encrypted)
            {
                encrypted.FlushFinalBlock();
            }
        }
    }
}