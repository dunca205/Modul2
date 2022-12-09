using System.Text;
using Xunit;

namespace StreamNamespace
{
    public class StreamFacts
    {
        [Fact]
        public void WriteToTheStreamAndRead()
        {
            var text = "ana are mere";
            var memorystream = new MemoryStream(text.Length);

            StreamClass.Write(memorystream, text, false, false);
            Assert.Equal(12, memorystream.Length);

            var memoryStreamBuffer = Encoding.ASCII.GetString(memorystream.GetBuffer());
            Assert.Equal(text, memoryStreamBuffer);
        }
    }
}