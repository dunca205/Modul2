using Xunit;

namespace StreamNamespace
{
    public class StreamFacts
    {
        [Fact]
        public void EncryptAndDecryptText()
        {
            var memorystream = new MemoryStream();
            StreamClass.StreamWrite(memorystream, "ana are mere", false, false);
            Assert.Equal(12, memorystream.Length);
        }
    }
}