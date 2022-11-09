global using Xunit;
namespace Collections
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void AddNumberOnObjectArray()
        {
            var objectArray = new ObjectArray { 10, 20, 30, 40};
            Assert.True(objectArray.Contains(20));
        }

        [Fact]
        public void AddWordAndCharacterOnObjectArray()
        {
            var objectArray = new ObjectArray { 10, 20, "mama" , 'c' };
            Assert.True(objectArray.Contains("mama"));
            Assert.True(objectArray.Contains('c'));
        }

        [Fact]
        public void ReturnTrueIfElementIsFoundAndRemoved()
        {
            var objectArray = new ObjectArray { 10, 20, 30, 40 };
            Assert.True(objectArray.Remove(10));
            Assert.False(objectArray.Remove(100));
        }

        [Fact]
        public void SetStringValueOnIntValue()
        {
            var objectArray = new ObjectArray { 10, 20, 30, 40 };
            objectArray[0] = "mama";
            Assert.Equal("mama", objectArray[0]);
        }
    }
}
