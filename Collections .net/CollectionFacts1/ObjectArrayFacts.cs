namespace Collections
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void AddNumbersOnObjectArray()
        {
            var objectArray = new ObjectArray { 10, 03, 20, 30, 40 };
            Assert.True(objectArray.Contains(20));
        }

        [Fact]
        public void AddWordAndCharacterOnObjectArray()
        {
            var objectArray = new ObjectArray { 10, 20, "mama", 'c' };
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

        [Fact]
        public void GetEnumeratorForMinimumLengthArrayWhenAllPositionsAreFilled()
        {
            var objectArray = new ObjectArray { 1, 2, 3, 4 };
            var enumerator = objectArray.GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
                Assert.True(enumerator.Current != null);
            }
            Assert.Equal(4, count);

        }

        [Fact]
        public void GetEnumeratorWhenNotAllPositionsAreFilled()
        {
            var enumerator = new ObjectArray { 1, 2, 3, 4, 5 }.GetEnumerator();  
            while (enumerator.MoveNext())
            {
                Assert.True(enumerator.Current != null);
            }
        }
    }
}
