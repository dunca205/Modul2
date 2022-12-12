using System.IO.Compression;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace StreamNamespace
{
    public class StreamClass
    {
        public static string Read(Stream stream, bool decrypt, bool decompress)
        {
            string streamContent = "";
            stream.Position = 0;

            if (decrypt)
            {
                using (var cryptic = new DESCryptoServiceProvider())
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    using CryptoStream decryptor = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

                    StreamReader decrypted = new StreamReader(decryptor);
                    streamContent = decrypted.ReadToEnd();
                }

                return streamContent;
            }

            if (decompress)
            {
                using var decompressor = new GZipStream(stream, CompressionMode.Decompress);
                StreamReader decompressed = new StreamReader(decompressor);
                streamContent = decompressed.ReadToEnd();
                return streamContent;
            }

            StreamReader fromStream = new StreamReader(stream);
            streamContent = fromStream.ReadToEnd();
            stream.Close();
            return streamContent;
          
        }

        public static void Write(Stream stream, string text, bool encrypt, bool compress)
        {
            if (compress)
            {
                stream = new GZipStream(stream, CompressionMode.Compress);
             //   using var compressor = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
                StreamWriter toCompressor = new StreamWriter(stream);
                toCompressor.Write(text);
                toCompressor.Flush();
                return;
              
            }

            if (encrypt)
            {
                using (var cryptic = new DESCryptoServiceProvider())
                {
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                    stream.Position = 0;
                    using CryptoStream encryptor = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write, leaveOpen: true);
                    StreamWriter toEncryptor = new StreamWriter(encryptor);
                    toEncryptor.Write(text);
                    toEncryptor.Flush();
                }

                return;
            }

                StreamWriter toStream = new StreamWriter(stream);
                toStream.Write(text);
                toStream.Flush();
        }
    }
}