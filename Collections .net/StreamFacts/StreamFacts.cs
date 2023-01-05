using Xunit;

namespace StreamNamespace
{
    public class Stream
    {
        
        [Fact]
        public void JustWriteAndRead()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, false, false);
            string memoryStreamContent = StreamClass.Read(memorystream, false, false);
            Assert.Equal(text, memoryStreamContent);
        }

        [Fact]
        public void CompressASmallText_StreamLengthIsDifferentWhenTextIsCompressed()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, false, true);
            Assert.True(memorystream.Length != text.Length);
        }

        [Fact]
        public void CompressALargeText_CompressedStreamIsSmaller()
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, false, true);
            Assert.True(memorystream.Length < text.Length);
        }

        [Fact]
        public void CompresAndDecompress_StreamLengthIsEqualWithTextLength()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, false, true);
            int decompressedTextLength = StreamClass.Read(memorystream, false, true).Length;
            Assert.Equal(text.Length, decompressedTextLength);
        }

        [Fact]
        public void EncryptAndDecryptText_DecryptedTextIsEqualWithText()
        {
            var text = "cristina";
            var memorystream = new MemoryStream();
            StreamClass.Write(memorystream, text, true, false);
            string decryptedText = StreamClass.Read(memorystream, true, false);
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
    }
}