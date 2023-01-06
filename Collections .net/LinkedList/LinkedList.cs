using System.Collections;

namespace LinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        // System.Collections.Generic.LinkedListNode<T> node;
        // System.Collections.Generic.LinkedList<T> node;

        private Node<T> tail = new Node<T>(default); // == ultimul nod din lista, pointerNext => primulnod, pointer.prev => ultumulnod

        public CircularDoublyLinkedList()
        {
            tail.Next = tail;
            tail.Prev = tail;
            tail.List = this;
        }
        public Node<T> Last { get => tail.Prev.Next; }
        //  tail.Prev => penultimul nod, tail.Prev.Next => adresa ultimului nod
        public Node<T> First { get => tail.Next; }

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
            if (Count == 0) // add as first node
            {
                tail = newNode;
                tail.Next = tail.Prev = newNode;
                Count++;
                newNode.List = this;
                return;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next = newNode;
            newNode.Next.Prev = newNode;
            newNode.List = this;
            Count++;

            if (current == Last)
            {
                // daca nu pun aceasta conditie si este true tail nu se modifica => nici last si first nu se modifica
                tail = newNode; /*noul nod va devenii ultimul din lista*/
            }
        }

        public Node<T> AddAfter(Node<T> current, T value)
        {
            var newNode = new Node<T>(value);
            AddAfter(current, newNode);
            return newNode;
        }

        public void AddBefore(Node<T> current, Node<T> newNode)
        {
            newNode.Next = current;
            newNode.Prev = current.Prev;
            newNode.Prev.Next = newNode;
            current.Prev = newNode;
            Count++;
            newNode.List = this;

            //if(current == Last) // daca se adauga inaintea primului nod
            //{
            //    tail.Next = newNode; 
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
            Add(node);
        }

        public Node<T> AddLast(T value)
        { 
            var newNode = new Node<T>(value);
            AddLast(newNode);
            return newNode;
        }

        public Node<T> Find(T value)
        {
            return tail;
        }
        public Node<T> FindLast(T value)
        {
            return tail;
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