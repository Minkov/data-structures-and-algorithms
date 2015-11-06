namespace Heap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Heap<T> where T : IComparable<T>
    {
        private List<T> values;
        private IComparer<T> comparer;

        public Heap()
            : this(Comparer<T>.Default)
        {
        }

        public Heap(Func<T, T, int> predicate)
            : this(new DelegateComparer<T>(predicate))
        {
        }

        public Heap(IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.values = new List<T>();
        }

        public Heap(IEnumerable<T> collection)
            : this()
        {
            this.values.ToList()
                       .ForEach(this.Push);
        }

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public void Push(T item)
        {
            this.values.Add(item);
            int index = this.Count - 1;

            var parent = this.values[index / 2];
            var current = this.values[index];

            while (index > 0 && this.comparer.Compare(parent, current) > 0)
            {
                this.Swap(index, index / 2);
                index /= 2;
                parent = this.values[index / 2];
                current = this.values[index];
            }
        }

        public T Pop()
        {
            T value = this.values[0];
            this.values[0] = this.values[this.Count - 1];
            this.values.RemoveAt(this.Count - 1);

            int index = 0;
            while (index < this.Count)
            {
                int min = index;
                for (int i = 1; i <= 2; i++)
                {
                    var childIndex = (2 * index) + i;
                    if (childIndex < this.Count && this.comparer.Compare(this.values[childIndex], this.values[min]) < 0)
                    {
                        min = childIndex;
                    }
                }

                if (min == index)
                {
                    break;
                }
                else
                {
                    T tmp = this.values[index];
                    this.values[index] = this.values[min];
                    this.values[min] = tmp;
                    index = min;
                }
            }

            return value;
        }

        public T Peek()
        {
            if (this.values.Count == 0)
            {
                throw new NullReferenceException("No items in the heap");
            }

            return this.values[0];
        }

        private void Swap(int i, int j)
        {
            T temp = this.values[j];
            this.values[j] = this.values[i];
            this.values[i] = temp;
        }
    }
}