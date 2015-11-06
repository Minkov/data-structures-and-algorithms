namespace LinearDataStructures
{
    using System.Collections.Generic;

    public interface IQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        T Peek();

        void Enqueue(T value);

        T Dequeue();

        bool IsEmpty();
    }
}