namespace HashTables
{
    using System.Collections.Generic;

    public interface IHashSet<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T value);

        bool Contains(T value);

        void Remove(T value);
    }
}