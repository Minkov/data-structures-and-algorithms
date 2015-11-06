namespace LinearDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IQueue<T>
    {
        private readonly LinkedList<T> list;

        public Queue()
        {
            this.list = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Enqueue(T value)
        {
            this.list.AddLast(value);
        }

        public T Dequeue()
        {
            var value = this.list.First;
            this.list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            return this.list.First;
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
