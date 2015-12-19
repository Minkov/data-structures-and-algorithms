namespace LinearDataStructures
{
    using System.Collections.Generic;

    public interface ILinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        T First { get; }

        T Last { get; }

        void AddFirst(T value);

        void AddLast(T value);

        T ElementAt(int index);

        void RemoveFirst();

        void RemoveLast();

        bool IsEmpty();
    }
}