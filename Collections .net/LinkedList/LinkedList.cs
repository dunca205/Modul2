using System.Collections;

namespace LinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        private Node<T> sentinel = new Node<T>(default);

        public CircularDoublyLinkedList()
        {
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
            sentinel.List = this;
        }
        public Node<T> Last { get => sentinel.Prev; }

        public Node<T> First { get => sentinel.Next; }

        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            Add(new Node<T>(item));

        }
        public void Add(Node<T> newNode)
        {
            AddAfter(Last, newNode);
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
            AddAfter(current.Prev, newNode);
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

        public Node<T> Find(T value)
        {

            for (var temp = First; temp != Last; temp = temp.Next)
            {
                if (temp.Value.Equals(value))
                {
                    return temp;
                }
            }

            return null;
        }
        public Node<T> FindLast(T value)
        {
            for (var temp = Last; temp != First; temp = temp.Prev)
            {
                if (temp.Value.Equals(value))
                {
                    return temp;
                }
            }

            return null;
        }
        public void Remove(Node<T> current)
        {
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            current.List = null;
            current.Next = null;
            current.Prev = null;
            Count--;
        }
        public bool Remove(T item)
        {
            var nodeToRemove = Find(item);
            if (nodeToRemove != null)
            {
                Remove(nodeToRemove);
                return true;
            }

            return false;
        }
        public void RemoveFirst()
        {
            Remove(First);

        }
        public void RemoveLast()
        {
            Remove(Last);
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel.Prev = null;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (var iterator = First; iterator != Last.Next; iterator = iterator.Next)
            {
                array[arrayIndex] = iterator.Value;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var iterator = First; iterator != Last.Next; iterator = iterator.Next)
            {
                yield return iterator.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}