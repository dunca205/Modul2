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

            if (decompress) // daca le inversez :"The archive entry was compressed using an unsupported compression method."
            {
                stream = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true);
            }

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
            
            StreamReader fromStream = new StreamReader(stream);
            return fromStream.ReadToEnd(); ;
        }

        public static void Write(Stream stream, string text, bool encrypt, bool compress)
        {
            if (compress)
            {
                stream = new GZipStream(stream, CompressionMode.Compress, leaveOpen:true);
            }

            if (encrypt)
            {
                var cryptic = new DESCryptoServiceProvider();
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.Padding = PaddingMode.None; // Padding is invalid and cannot be removed.
                stream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write, leaveOpen: true);
                stream.Flush();
            }

            StreamWriter toStream = new StreamWriter(stream);
            toStream.Write(text);
            toStream.Flush();
        }
    }
}