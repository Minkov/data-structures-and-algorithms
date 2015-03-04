using System;
namespace Lists
{
    interface IList<T>
    {
        void Add(T value);
        int Count { get; }
        T this[int index] { get; set; }
    }
}
