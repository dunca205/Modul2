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
            Assert.Equal(3, list.Last.Value);

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

        [Fact]
        public void AddBeforeWhenIsJustOneNodeInTheList()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            list.Add(node0);
            Assert.Equal(node0, list.Last);
            list.AddBefore(node0, node2);
            Assert.Equal(node2, list.First);
            Assert.Equal(node0, list.Last);
           
        }

        [Fact]
        public void AddBeforeFirstNode_NewNodeBecomesFirstNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            list.Add(node0);
            list.Add(node2);

            list.AddBefore(node0, node4); 
            Assert.Equal(node4, list.First); // node4 este primul nod,
            Assert.Equal(node4, node2.Next); // node2 - este ultimul din lista
            Assert.Equal(node0, node4.Next); // node0 urmeaza dupa node4
            Assert.Equal(node2, list.Last);  // nodul 2 este  ultimul din lista

        }
        [Fact]
        public void AddBeforeNodeInBetweenNodes()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);

            list.Add(node0);
            list.Add(node2);
            list.Add(node4);

            var node3 = new Node<int>(3);
            list.AddBefore(node4, node3);

            Assert.Equal(node2, node3.Prev); // inainte de nodul 3 este nodul 2
            Assert.Equal(node4, node3.Next); //dupa nodul 3 este nodul4
            Assert.Equal(node3, node4.Prev); // inainte de nodul 4 este nodul3
        }

        [Fact]
        public void AddNewNodeToFirstPosition()
        {
            var list = new CircularDoublyLinkedList<int>
            {
                new Node<int>(0)
            };

            var node2 = new Node<int>(2);

            list.AddFirst(node2);
            Assert.True(node2 == list.First);
            Assert.True( list.Last.Value == 0);

        }
        [Fact]
        public void AddNewNodeToLastPosition()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            list.Add(node0);
            list.Add(2);
            list.AddLast(new Node<int>(4));
            Assert.True(list.Last.Value == 4);
            Assert.True(node0.Prev.Value == 4);
        }


       
    }
}