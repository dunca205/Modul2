using System.Collections;

namespace LinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        private Node<T> sentinel = new Node<T>(default);
       // new LinkedList<T> head = new LinkedList<T>();

        public CircularDoublyLinkedList()
        {
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
            sentinel.List = this;
        }
        public Node<T> Last { get => Count == 0 ? null : sentinel.Prev; }
       
        public Node<T> First { get  =>  Count == 0 ? null : sentinel.Next; }

        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            Add(new Node<T>(item));
        }
        public void Add(Node<T> newNode)
        {
            AddAfter(sentinel.Prev, newNode);
        }

        public void AddAfter(Node<T> current, Node<T> newNode)
        {
        // T: System.ArgumentNullException:
        //     node is null. -or- newNode is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1. -or- newNode
        //     belongs to another System.Collections.Generic.LinkedList`1. 
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
            AddBefore(sentinel.Next, node);
        }

        public Node<T> AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            AddFirst(newNode);
            return newNode;
        }

        public void AddLast(Node<T> node)
        {
            AddAfter(sentinel.Prev, node);
        }

        public Node<T> AddLast(T value)
        {
            var newNode = new Node<T>(value);
            AddLast(newNode);
            return newNode;
        }

        public Node<T> Find(T value)
        {
            for (var temp = sentinel.Next; temp != sentinel; temp = temp.Next)
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
            for (var temp = sentinel.Prev; temp != sentinel; temp = temp.Prev)
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
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     node is null.
            //
            //   T:System.InvalidOperationException:
            //     node is not in the current System.Collections.Generic.LinkedList`1.
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
            //   T:System.InvalidOperationException:
            //     The System.Collections.Generic.LinkedList`1 is empty.
            Remove(First);

        }
        public void RemoveLast()
        {
            // Exceptions:
            //   T:System.InvalidOperationException:
            //     The System.Collections.Generic.LinkedList`1 is empty.
            Remove(Last);
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel.Prev = sentinel;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
      //  Exceptions:
            //   T:System.ArgumentNullException:
            //     array is null.
            //
            //   T:System.ArgumentOutOfRangeException:
            //     index is less than zero.
            //
            //   T:System.ArgumentException:
            //     The number of elements in the source System.Collections.Generic.LinkedList`1
            //     is greater than the available space from index to the end of the destination
            //     array.
            for (var iterator = First; iterator != Last.Next; iterator = iterator.Next)
            {
                array[arrayIndex] = iterator.Value;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var iterator = sentinel.Next; iterator != sentinel; iterator = iterator.Next)
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