using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lists;

namespace Stacks
{
    public class LinkedStack<T> : IEnumerable<T>
    {
        private DoubleLinkedList<T> list;

        public LinkedStack()
            : this(new T[0])
        {
        }

        public LinkedStack(IEnumerable<T> collection)
        {
            this.list = new DoubleLinkedList<T>(collection);
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public T Head
        {
            get
            {
                return this.list.Head.Value;
            }
        }

        public void Push(T value)
        {
            this.list.AddFirst(value);
        }

        public T Pop()
        {
            var value = this.list.Head.Value;
            this.list.RemoveFirst();
            return value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}