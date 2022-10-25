global using Xunit;

namespace Collections
{
    public class CollectionsFacts
    {
        [Fact]
        public void AddOneLastElement()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            Assert.True(arraynumbers.Contains(1));
        }

        [Fact]
        public void CountArrayElements()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            arraynumbers.Add(2);
            arraynumbers.Add(10);
            Assert.Equal(3, arraynumbers.Count());
        }

        [Fact]
        public void SetElementOnCertainPositionAndCheckWhatElementIsOnCertainPosition()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            arraynumbers.Add(2);
            arraynumbers.SetElement(0, 20);
            Assert.Equal(20, arraynumbers.Element(0));
        }

        [Fact]
        public void ArrayContainsCertainElement()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            Assert.True(arraynumbers.Contains(100));
        }

        [Fact]
        public void ElementIsFoundAtCertainIndex()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(300);
            arraynumbers.Add(120);
            Assert.Equal(0, arraynumbers.IndexOf(100));
        }

        [Fact]
        public void ElementIsNotPresentInTheArray()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            Assert.Equal(-1, arraynumbers.IndexOf(0));
        }

        [Fact]
        public void InsertNewElementAtCertainPosition()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(300);
            arraynumbers.Add(120);
            arraynumbers.Insert(0, 400);
            Assert.Equal(400, arraynumbers.Element(0));
        }

        [Fact]
        public void ClearArray()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(300);
            arraynumbers.Add(120);
            arraynumbers.Clear();
            Assert.Equal(0, arraynumbers.Count());
        }

        [Fact]
        public void RemoveTheFirstAppearanceOfCertainNumber()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(100);
            arraynumbers.Add(120);
            arraynumbers.Remove(100);
            Assert.Equal(0, arraynumbers.Element(0));
            Assert.Equal(100, arraynumbers.Element(1));
        }

        [Fact]
        public void RemoveNumberAtCertainIndex()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(101);
            arraynumbers.Add(120);
            arraynumbers.RemoveAt(1);
            Assert.Equal(0, arraynumbers.Element(1));
        }

    }
}