namespace Heap
{
    using System;
    using System.Collections.Generic;

    public class DelegateComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> predicate;

        public DelegateComparer(Func<T, T, int> predicate)
        {
            this.predicate = predicate;
        }

        public int Compare(T x, T y)
        {
            return this.predicate(x, y);
        }
    }
}