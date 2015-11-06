using System;
using System.Collections.Generic;

namespace Trees
{
    public interface IBinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int Count { get; }

        void Add(T g);

        bool Contains(T value);

        void Remove(T value);
    }
}