global using Xunit;

namespace LinkedList
{
    public class LinkedListFacts
    {
        [Fact]
        public void AddFourNodesToList_CheckLastNodeValueAfterEachAddOperation()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(3);
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
        public void AddAfterNode_CheckValue()
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
        public void AddAfterLast_but_one() // dupa penultimul nod
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            list.Add(node0);
            list.Add(node2);
            list.Add(node4);

            var node3 = new Node<int>(3);
            list.AddAfter(node2, node3);
            Assert.Equal(node3, list.Last.Prev);
        }

        [Fact]
        public void AddBefore_WhenIsJustOneNodeInTheList()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            list.Add(node0);
            Assert.Equal(node0, list.Last);
            Assert.Equal(node0, list.First);

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
            Assert.Equal(node2, list.Last);
            Assert.Equal(node0, list.First);

            list.AddBefore(node0, node4);

            Assert.Equal(node4, list.First); 
            Assert.Equal(node2, list.Last); 
            Assert.Equal(node0.Value, node4.Next.Value);
            Assert.Equal(node2, list.Last);
        }

        [Fact]
        public void AddBeforeLastNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            list.Add(node0);
            list.Add(node2);
            list.AddBefore(node2, node4);
            Assert.Equal(node4, list.Last.Prev);
        }

        [Fact]
        public void AddBeforeNode_InBetweenNodes()
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
            Assert.True(list.Last.Value == 0);

        }

        [Fact]
        public void AddNewNodeToLastPosition()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            list.Add(node1);
            list.Add(node2);

            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);

            var node4 = new Node<int>(4);
            list.AddLast(node4);
            Assert.Equal(node4, list.Last);
            Assert.Equal(1, list.Last.Next.Next.Value);
            // primul Next -> duce la sentinel. next-> primul primul nod
        }

        [Fact]
        public void ClearList_LastAndFirstNodeShouldPointToNull()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);

            list.Add(node0);
            list.Add(node2);
            list.Add(node4);
            Assert.False(node4 is null);
            list.Clear();
            Assert.Null(list.First);
            Assert.Null(list.Last);// System.NullReferenceException
        }

        [Fact]
        public void GetEnumeratorForLinkedList()
        {
            var list = new CircularDoublyLinkedList<char>();
            list.Add('a');
            list.Add('b');
            list.Add('c');
            string abc = "";
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                abc += enumerator.Current;
            }
            Assert.Equal("abc", abc);
        }

        [Fact]
        public void FindFirstOccuranceOfLetterA()
        {
            var list = new CircularDoublyLinkedList<char>();
            list.Add('b');
            list.Add('a');
            list.Add('a');
            list.Add('c');
            var nodeA = list.Find('a');
            Assert.Equal('b', nodeA.Prev.Value);
            Assert.Equal('a', nodeA.Next.Value);
        }
        [Fact]
        public void FindLastOccuranceOfLetterA()
        {
            var list = new CircularDoublyLinkedList<char>
            {
                'b',
                'a',
                'a',
                'c'
            };
            var nodeA = list.FindLast('a');
            Assert.Equal('a', nodeA.Prev.Value);
            Assert.Equal('c', nodeA.Next.Value);
        }

        [Fact]
        public void ListContainsLetterA()
        {
            var list = new CircularDoublyLinkedList<char>
            {
                'b',
                'a',
                'a',
                'c'
            };
            Assert.True( list.Contains('a'));
        }

        [Fact]
        public void ListDoesntContainLetterA()
        {
            var list = new CircularDoublyLinkedList<char>
            {
                'b',
                'c'
            };
            Assert.False(list.Contains('a'));
        }

        [Fact]
        public void RemoveNodeFromInBetweenOtherNodes()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);

            list.Add(node0);
            list.Add(node2);
            list.Add(node4);
            Assert.True(list.Remove(2));
            Assert.Equal(node4,node0.Next);
            Assert.Equal(node0, node4.Prev);
            Assert.Equal(node4, list.First.Next);
            Assert.Equal(node0, list.Last.Prev);
        }

        [Fact]
        public void RemoveFirstNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);

            list.Add(node0);
            list.Add(node2);
            list.Add(node4);
            list.RemoveFirst();
            Assert.Equal(node2, list.First);
        }

        [Fact]
        public void RemoveLastNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            var node0 = new Node<int>(0);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);

            list.Add(node0);
            list.Add(node2);
            list.Add(node4);
            list.RemoveLast();
            Assert.Equal(node2, list.Last);
        }

        [Fact]
        public void RemoveInexistentNode()
        {
            var list = new CircularDoublyLinkedList<int> { 1, 2 };
            Assert.False(list.Remove(3));
        }

        [Fact]
        public void RemoveFromEmptyList()
        {
            var list = new CircularDoublyLinkedList<int>();
            Assert.False(list.Remove(2));
        }

        [Fact]
        public void CopyToArray()
        {
            var list = new CircularDoublyLinkedList<char>
            {
                'b',
                'a',
                'a',
                'c'
            };

            var charArray = new char[8];
            list.CopyTo(charArray, 4);
            Assert.Equal('b', charArray[4]);
            Assert.Equal(list.Last.Value, charArray[7]);
        }
    }
}