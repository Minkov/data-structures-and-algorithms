using System;
using System.Collections.Generic;

namespace Trees
{
    public interface IBinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int Count { get; }
        T Max { get; }
        int MaxCount { get; }
        T Min { get; }

        void Add(T g);
        bool Contains(T value);
        void Remove(T value);
        IEnumerable<T> GetBiggerThan(T from);
        IEnumerable<T> GetBiggerThan(T from, bool isExclusive);

        IEnumerable<T> GetSmallerThan(T to);
        IEnumerable<T> GetSmallerThan(T to, bool isExclusive);
        IEnumerable<T> GetRangeBetween(T from, T to);
        IEnumerable<T> GetRangeBetween(T from, T to, bool isExclusive);
    }
}