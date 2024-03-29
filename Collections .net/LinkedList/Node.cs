﻿namespace LinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            this.Next = null;
            this.Prev = null;
            this.List = null;
        }
        public CircularDoublyLinkedList<T> List { get; set; }
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }

    }
}
