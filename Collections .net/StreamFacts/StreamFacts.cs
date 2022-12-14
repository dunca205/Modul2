using System.IO.Compression;
using System.Security.Cryptography;
using Xunit;

namespace StreamNamespace
{
    public class StreamFacts
    {
        [Fact]
        public void CompressALargeText_CompressedStreamIsSmaller()
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var memorystream = new MemoryStream();
            Write(memorystream, text, false, true);
            Assert.True(memorystream.Length < text.Length);
        }

        [Fact]
        public void JustWriteAndRead()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            Write(memorystream, text, false, false);
            string memoryStreamContent = Read(memorystream, false, false);
            Assert.Equal(text, memoryStreamContent);
        }

        [Fact]
        public void CompressASmallText_StreamLengthIsDifferentWhenTextIsCompressed()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            Write(memorystream, text, false, true);
            Assert.True(memorystream.Length != text.Length);
        }

        [Fact]
        public void CompresAndDecompress_AfterStreamIsDecompressed_StreamLengthIsEqualWithTextLength()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            Write(memorystream, text, false, true);
            int decompressedTextLength = Read(memorystream, false, true).Length;
            Assert.Equal(text.Length, decompressedTextLength);
        }

        [Fact]
        public void EncryptTextAndRead_EncryptedTextIsDifferentThanText()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            Write(memorystream, text, true, false);
            string cryptedText = (Read(memorystream, false, false));
            Assert.NotEqual(cryptedText, text);
        }

        [Fact]
        public void EncryptAndDecryptText_DecryptedTextIsEqualWithText()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            Write(memorystream, text, true, false);
            string decryptedText = Read(memorystream, true, false);
            Assert.Equal(text, decryptedText);
        }

        [Fact]
        public void EncryptAndCompress_ThenDecryptAndDecompress()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, true, true);
            string decryptedAndDecompressedText = StreamClass.Read(memorystream, true, true);
            Assert.Equal(text, decryptedAndDecompressedText);
        }

        static Aes aesAlgorithm = Aes.Create();
        static string Read(Stream stream, bool decrypt = false, bool decompress = false)
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

        static void Write(Stream stream, string text, bool encrypt = false, bool compress = false)
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
