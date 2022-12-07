using System.IO;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Stream
{
    public class StreamFacts
    {
        [Fact]
        public void EncryptAndDecryptText()
        {
            string path = "TextFile.txt";
            string text = "Azi este miercuri";
            string cryptedText = File.ReadAllText("EncryptedFile.txt");
            Stream.StreamWrite(path, text, true,false);
            Assert.False(text.Equals(cryptedText));
            Stream.StreamRead(path, true, false);
            string decryptedText = File.ReadAllText("DecryptedFile.txt");
            Assert.True(text.Equals(decryptedText));

        }
    }
}