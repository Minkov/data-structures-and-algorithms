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

            while (index > 0)
            {
                var parentIndex = (index - 1) / 2;
                if (this.comparer.Compare(this.values[parentIndex], this.values[index]) <= 0)
                {
                    break;
                }
                this.Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        public T Pop()
        {
            int currentIndex = 0;

            T value = this.values[currentIndex];
            this.values[currentIndex] = this.values[this.Count - 1];
            this.values.RemoveAt(this.Count - 1);

            while (currentIndex < this.Count)
            {
                bool hasFoundSmaller = false;
                int newIndex = currentIndex;

                for (int i = 1; i <= 2; i++)
                {
                    int nextIndex = (2 * currentIndex) + i;
                    if (nextIndex >= this.Count)
                    {
                        continue;
                    }
                    if (this.comparer.Compare(this.values[newIndex], this.values[nextIndex]) > 0)
                    {
                        newIndex = nextIndex;
                        hasFoundSmaller = true;
                    }
                }
                if (hasFoundSmaller)
                {
                    this.Swap(currentIndex, newIndex);
                    currentIndex = newIndex;
                }
                else
                {
                    break;
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

            return this.values[1];
        }

        public void Print()
        {
            this.Print(0, "-");
        }

        private void Print(int index, string indent)
        {
            if (index >= this.Count)
            {
                return;
            }
            Console.WriteLine("{0}{1}", indent, this.values[index]);
            this.Print(2 * index + 1, indent + "-");
            this.Print(2 * index + 2, indent + "-");
        }

        private void Swap(int i, int j)
        {
            T temp = this.values[j];
            this.values[j] = this.values[i];
            this.values[i] = temp;
        }
    }
}