using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace StreamNamespace
{
    public class StreamClass
    {
        public static string Read(Stream stream, bool decrypt, bool decompress)
        {
            stream.Position = 0;

            if (decrypt)
            {
                using (var cryptic = new DESCryptoServiceProvider())
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    cryptic.Padding = PaddingMode.None;
                    stream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read, leaveOpen: true);
                }
            }

            if (decompress)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            StreamReader fromStream = new StreamReader(stream);
            return fromStream.ReadToEnd();
        }

        public static void Write(Stream stream, string text, bool encrypt, bool compress)
        {
            if (compress)
            {
                stream = new GZipStream(stream, CompressionMode.Compress);
            }

            if (encrypt)
            {
                var cryptic = new DESCryptoServiceProvider();
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.Padding = PaddingMode.None;
                stream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write, leaveOpen: true);
            }

            StreamWriter toStream = new StreamWriter(stream);
            toStream.Write(text);
            toStream.Flush();
        }
    }
}