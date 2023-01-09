using System.Collections;

namespace LinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        // System.Collections.Generic.LinkedListNode<T> node;
        // System.Collections.Generic.LinkedList<T> node;

        private Node<T> sentinel = new Node<T>(default); // == ultimul nod din lista, pointerNext => primulnod, pointer.prev => ultumulnod

        public CircularDoublyLinkedList()
        {
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
            sentinel.List = this;
        }
        public Node<T> Last
        {
            get => sentinel.Prev;
            set { sentinel.Prev = value; }
        }

        public Node<T> First { get => sentinel.Next; set { sentinel.Next = value; } }

        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            Add(new Node<T>(item));

        }
        public void Add(Node<T> newNode)
        {
            AddAfter(Last, newNode); // add next
        }

        public void AddAfter(Node<T> current, Node<T> newNode)
        {
            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next = newNode;
            newNode.Next.Prev = newNode;

            newNode.List = this;
            Count++;
        }

        public Node<T> AddAfter(Node<T> current, T value)
        {
            var newNode = new Node<T>(value);
            AddAfter(current, newNode);
            return newNode;
        }

        public void AddBefore(Node<T> current, Node<T> newNode)
        {
            //  AddAfter(current.Prev, newNode);
            newNode.Next = current;
            newNode.Prev = current.Prev;
            newNode.Prev.Next = newNode;
            current.Prev = newNode;
            Count++;
            newNode.List = this;

            //if (current == Last) // daca se adauga inaintea primului nod
            //{
            //    sentinel = newNode;
            //}
        }

        public Node<T> AddBefore(Node<T> current, T value)
        {
            var newNode = new Node<T>(value);
            AddBefore(current, newNode);

            return newNode;
        }

        public void AddFirst(Node<T> node)
        {
            AddBefore(First, node);
        }

        public Node<T> AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            AddFirst(newNode);
            return newNode;

        }

        public void AddLast(Node<T> node)
        {
            AddAfter(Last, node);
        }

        public Node<T> AddLast(T value)
        {
            var newNode = new Node<T>(value);
            AddLast(newNode);
            return newNode;
        }

        public Node<T> Find(T value) // incepem cu primul nod
        {
            var temp = First;
            while (temp != Last)
            {
                if (temp.Value.Equals(value))
                {
                    return temp;
                }

                temp = temp.Next;
            }

            return null;
        }
        public Node<T> FindLast(T value)
        {
            var temp = Last; // santinel in sine
            while (temp != First)
            {
                if (temp.Value.Equals(value))
                {
                    return temp;
                }

                temp = temp.Prev;
            }

            return null;
        }
        public void Remove(Node<T> node)
        {

        }
        public bool Remove(T item)
        {
            Remove(new Node<T>(item));
            return true;
        }
        public void RemoveFirst()
        {
            // incepe de la First

        }
        public void RemoveLast()
        {
            // incepe de la Last 
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel.Prev = default;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int enumeratorCounter = Count;
            var temp = First;
            while (enumeratorCounter > 0)
            {
                yield return temp.Value;
                temp = temp.Next;
                enumeratorCounter--;
            }
            //incepem de la first // daca parcurgem in sens invers incepem cu last, si tempNode.prev
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}