global using Xunit;
namespace LinkedList
{
    public class LinkedListFacts
    {
        [Fact]
        public void AddFourNodesToList_CheckLastNodeAfterEachAddOperation()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(new Node<int>(3));
            Assert.Equal(3,list.Last.Value);

            list.Add(new Node<int>(56));
            Assert.Equal(56, list.Last.Value);

            list.Add(new Node<int>(value: 4));
            Assert.Equal(4, list.Last.Value);

            list.Add(new Node<int>(190));
            Assert.Equal(190, list.Last.Value);
            Assert.Equal(3, list.First.Value);
            Assert.Equal(4, list.Count);
        }

        [Fact]
        public void AddAfterNode_CheckNextValue()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            list.Add(node0);
            list.Add(node2);
            list.Add(node4);
            list.AddAfter(node2, new Node<int>(3));
            Assert.True(node2.Next.Value == 3);
            Assert.True(node4.Prev.Value == 3);
            Assert.Equal(4, list.Count);
            Assert.Equal(0, list.First.Value);
            Assert.Equal(4, list.Last.Value);
        }
    }
}