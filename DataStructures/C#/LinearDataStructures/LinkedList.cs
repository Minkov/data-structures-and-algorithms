namespace LinearDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Extensions;

    public class LinkedList<T> : ILinkedList<T>
    {
        private LinkedListNode<T> firstNode;
        private LinkedListNode<T> lastNode;

        public LinkedList()
        {
            this.Count = 0;
            this.firstNode = null;
            this.lastNode = null;
        }

        public LinkedList(IEnumerable<T> collection)
            : this()
        {
            collection.ForEach(this.AddLast);
        }

        public T First
        {
            get
            {
                if (this.firstNode == null)
                {
                    throw new ArgumentOutOfRangeException(paramName: "Count", message: "No elements in the list");
                }

                return this.firstNode.Value;
            }
        }

        public T Last
        {
            get
            {
                if (this.lastNode == null)
                {
                    throw new ArgumentOutOfRangeException(paramName: "Count", message: "No elements in the list");
                }

                return this.lastNode.Value;
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (this.firstNode == null)
            {
                this.firstNode = newNode;
                this.lastNode = newNode;
            }
            else
            {
                newNode.Next = this.firstNode;
                this.firstNode.Previous = newNode;
                this.firstNode = newNode;
            }
            ++this.Count;
        }

        public void AddLast(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (this.lastNode == null)
            {
                this.firstNode = newNode;
                this.lastNode = newNode;
            }
            else
            {
                newNode.Previous = this.lastNode;
                this.lastNode.Next = newNode;
                this.lastNode = newNode;
            }
            ++this.Count;
        }

        public void RemoveFirst()
        {
            if (this.firstNode == null)
            {
                throw new ArgumentNullException(paramName: "No elements to remove");
            }

            this.firstNode = this.firstNode.Next;
            if (this.firstNode != null)
            {
                this.firstNode.Previous = null;
            }

            --this.Count;
        }

        public void RemoveLast()
        {
            if (this.lastNode == null)
            {
                throw new ArgumentNullException(paramName: "No elements to remove");
            }
            --this.Count;
            this.lastNode = this.lastNode.Previous;
            if (this.lastNode != null)
            {
                this.lastNode.Next = null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.firstNode != null)
            {
                yield return this.firstNode.Value;
                this.firstNode = this.firstNode.Next;
            }
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(paramName: "Index was not in the range of the list");
            }

            LinkedListNode<T> node = this.firstNode;

            for (int i = 0; i < index + 1; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        private class LinkedListNode<V>
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public LinkedListNode<V> Next { get; set; }

            public LinkedListNode<V> Previous { get; set; }
        }
    }
}
