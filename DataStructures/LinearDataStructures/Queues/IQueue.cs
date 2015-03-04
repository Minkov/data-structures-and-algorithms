using System;
namespace Queues
{
    interface IQueue<T>
    {
        int Count { get; }
        T Dequeue();
        void Enqueue(T item);
        T Head { get; }
    }
}
