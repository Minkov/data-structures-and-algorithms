using System;
using System.Collections.Generic;

namespace Lists
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public class DoubleLinkedListNode<T>
        {
            public DoubleLinkedListNode<T> Prev { get; set; }

            public DoubleLinkedListNode<T> Next { get; set; }

            public T Value { get; set; }

            public DoubleLinkedListNode(T value)
            {
                this.Value = value;
            }
        }

        public int Count { get; private set; }

        public DoubleLinkedListNode<T> Head { get; private set; }

        public DoubleLinkedListNode<T> Tail { get; private set; }

        public DoubleLinkedList()
            : this(new T[0])
        {
        }

        public DoubleLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DoubleLinkedListNode<T>(value);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Head.Prev = newNode;
                newNode.Next = this.Head;
                this.Head = newNode;
            }
            ++this.Count;
        }

        public void AddLast(T value)
        {
            var newNode = new DoubleLinkedListNode<T>(value);
            if (this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                newNode.Prev = this.Tail;
                this.Tail = newNode;
            }
            ++this.Count;
        }

        public void RemoveFirst()
        {
            if (this.Head == null)
            {
                return;
            }
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Prev = null;
            }
            --this.Count;
        }

        public void RemoveLast()
        {
            if (this.Tail == null)
            {
                return;
            }
            this.Tail = this.Tail.Prev;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            --this.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}