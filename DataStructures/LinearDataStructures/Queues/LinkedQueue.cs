using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lists;

namespace Queues
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private DoubleLinkedList<T> list;

        public LinkedQueue()
            : this(new T[0])
        {

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

        public LinkedQueue(IEnumerable<T> collection)
        {
            this.list = new DoubleLinkedList<T>(collection);
        }

        public void Enqueue(T item)
        {
            this.list.AddLast(item);
        }

        public T Dequeue()
        {
            var item = list.Head;
            list.RemoveFirst();
            return item.Value;
        }
    }
}
