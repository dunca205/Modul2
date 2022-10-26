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
        public void AddMoreThanFiveElements()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            arraynumbers.Add(2);
            arraynumbers.Add(3);
            arraynumbers.Add(4);
            arraynumbers.Add(5);
            Assert.Equal(5, arraynumbers.Count());
        }

        [Fact]
        public void AddNextElementOnNextAvaiablePosition()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            arraynumbers.Add(100);
            arraynumbers.RemoveAt(1);
            arraynumbers.Add(3);
            arraynumbers.Add(5);
            arraynumbers.Add(2);
            Assert.Equal(2, arraynumbers.Element(3));
            Assert.Equal(4, arraynumbers.Count());

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
            Assert.Equal(-1, arraynumbers.IndexOf(5));
        }

        [Fact]
        public void InsertNewElementAtCertainPosition()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(300);
            arraynumbers.Add(120);
            arraynumbers.Insert(1, 400);
            Assert.Equal(400, arraynumbers.Element(1));
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
            arraynumbers.Add(200);
            arraynumbers.Add(200);
            arraynumbers.Add(120);
            arraynumbers.Remove(200);
            Assert.Equal(100, arraynumbers.Element(0));
            Assert.Equal(200, arraynumbers.Element(1));

        }

        [Fact]
        public void InsertOneElement()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(1);
            arraynumbers.Add(2);
            arraynumbers.Add(3);
            arraynumbers.Add(4);
            arraynumbers.Insert(1, 6);
            Assert.Equal(1, arraynumbers.IndexOf(6));

        }

        [Fact]
        public void RemoveAtNumberAtCertainIndex()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(101);
            arraynumbers.Add(120);
            arraynumbers.RemoveAt(1);
            arraynumbers.RemoveAt(5);
            Assert.Equal(120, arraynumbers.Element(1));
        }

        [Fact]
        public void RemoveAtInexistentElement()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(101);
            arraynumbers.Add(120);
            arraynumbers.RemoveAt(4);
            Assert.Equal(3, arraynumbers.Count());
        }

        [Fact]
        public void RemoveInexistentElement()
        {
            var arraynumbers = new IntArray();
            arraynumbers.Add(100);
            arraynumbers.Add(101);
            arraynumbers.Add(120);
            arraynumbers.Remove(4);
            Assert.Equal(3, arraynumbers.Count());
        }
    }
}