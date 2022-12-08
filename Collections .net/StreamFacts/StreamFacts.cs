using Xunit;

namespace StreamProject
{
    public class StreamFacts
    {
        [Fact]
        public void EncryptAndDecryptText()
        {
            var memorystream = new MemoryStream();
            var newStream = new Stream(memorystream);
            newStream.StreamWrite("ana are mere", true, true);

        }
    }
}