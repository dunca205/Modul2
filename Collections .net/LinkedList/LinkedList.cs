using System.Collections;

namespace LinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        // System.Collections.Generic.LinkedListNode<T> node;
        // System.Collections.Generic.LinkedList<T> node;

        private Node<T> head = new Node<T>(default); // == ultimul el din lista, pointerNext => primulnod, pointer.prev => ultumulnod

        public CircularDoublyLinkedList()
        {
            head.Next = head;
            head.Prev = head;
            head.List = this; // nodul face parte din lista
        }
        public Node<T> Last { get => head.Prev.Next; }

        public Node<T> First { get => head.Next; }


        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(T item) 
        {
            Add(new Node<T>(item));
        }
        public void Add(Node<T> newNode)
        {
            if (Count == 0) // add as first node
            {
                head = newNode;
                head.Next = newNode;
                head.Prev = newNode;
                Count++;
                newNode.List = this;
                return;
            }
            
            AddAfter(head, newNode); // add next
            head = newNode;
            return;

        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            // nodul b =  nodul care urmaza dupa node
            newNode.Next = node.Next; //il legam pe newnode de nodul care urma initial dupa node
            newNode.Prev = node; // node va fi inainte lui newnode
            // === am dat adrese catre prev si next la noul nod
            newNode.Next.Prev = newNode; // actualizam nodul b -> adresa prev
            node.Next = newNode; // nodul anterior va avea adresa.next a noului nod
            Count++;
            newNode.List = this;
            if(node == Last)
            {
                head = newNode;
            }
        }

        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            AddAfter(node, newNode);
            return newNode;
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        { }

        public Node<T> AddBefore(Node<T> node, T value)
        { return node; }

        public void AddFirst(Node<T> node)
        {
            AddAfter(First, node);
        }

        public Node<T> AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            AddFirst( newNode);
            return newNode;

        }

        public void AddLast(Node<T> node)
        { }

        public Node<T> AddLast(T value)
        { return head; }

        public Node<T> Find(T value)
        {
            return head;
        }
        public Node<T> FindLast(T value)
        {
            return head;
        }
        public void Remove(Node<T> node)
        {
        }
        public bool Remove(T item)
        {
            return true;
        }
        public void RemoveFirst()
        {

        }
        public void RemoveLast()
        {

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}