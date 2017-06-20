using Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Swap<T>(T[] items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        #region QuickSort

        static T[] QuickSort<T>(T[] items) where T : IComparable<T>
        {
            var toBeSortedItems = items.Select(x => x).ToArray();
            QuickSort(toBeSortedItems, 0, toBeSortedItems.Length - 1);
            return toBeSortedItems;
        }

        static void QuickSort<T>(T[] items, int start, int end) where T : IComparable<T>
        {
            if (start < end)
            {
                int partition = Partition(items, start, end);
                QuickSort(items, start, partition - 1);
                QuickSort(items, partition + 1, end);
            }
        }

        private static int Partition<T>(T[] items, int start, int end) where T : IComparable<T>
        {
            var pivot = start;
            var value = items[pivot];

            //swap
            Swap(items, pivot, end);

            var index = start;
            for (int i = start; i <= end; i++)
            {
                if (items[i].CompareTo(value) < 0)
                {
                    Swap(items, i, index);
                    ++index;
                }
            }

            Swap(items, index, end);
            return index;
        }

        #endregion

        #region MergeSort

        private static T[] MergeSort<T>(T[] items) where T : IComparable<T>
        {
            var toBeSortedItems = items.Select(x => x).ToArray();

            T[] tempArray = new T[items.Length];
            MergeSort(toBeSortedItems, 0, toBeSortedItems.Length - 1, tempArray);

            return toBeSortedItems;
        }

        private static void MergeSort<T>(T[] items, int from, int to, T[] tempArray) where T : IComparable<T>
        {
            if (from < to)
            {
                int middle = (from + to) / 2;
                MergeSort(items, from, middle, tempArray);
                MergeSort(items, middle + 1, to, tempArray);
                Merge(items, from, to, tempArray);
            }
        }

        private static void Merge<T>(T[] items, int from, int to, T[] tempArray) where T : IComparable<T>
        {
            int middle = (from + to) / 2;

            int left = from;
            int right = middle + 1;
            int pos = from;

            while ((left <= middle) && (right <= to))
            {
                if (items[left].CompareTo(items[right]) < 0)
                {
                    tempArray[pos] = items[left];
                    ++left;
                }
                else
                {
                    tempArray[pos] = items[right];
                    ++right;
                }
                ++pos;
            }

            while (left <= middle)
            {
                tempArray[pos] = items[left];
                ++pos;
                ++left;
            }
            while (right <= to)
            {
                tempArray[pos] = items[right];
                ++pos;
                ++right;
            }

            for (int i = from; i <= to; i++)
            {
                items[i] = tempArray[i];
            }
        }

        #endregion

        #region BubbleSort

        static T[] BubbleSort<T>(T[] items) where T : IComparable<T>
        {
            T[] sortedItems = (T[])items.Clone();

            bool isSwapDone = false;
            do
            {
                isSwapDone = false;
                for (int j = 0; j < sortedItems.Length - 1; j++)
                {
                    if (sortedItems[j].CompareTo(sortedItems[j + 1]) > 0)
                    {
                        isSwapDone = true;
                        Swap(sortedItems, j, j + 1);
                    }
                }
            } while (isSwapDone);

            return sortedItems;
        }

        #endregion

        #region SelectionSort

        static T[] SelectionSort<T>(T[] items) where T : IComparable<T>
        {
            var sortedItems = (T[])items.Clone();

            for (int i = 0; i < sortedItems.Length; i++)
            {
                for (int j = sortedItems.Length - 1; j > i; j--)
                {
                    if (sortedItems[i].CompareTo(sortedItems[j]) > 0)
                    {
                        Swap(sortedItems, i, j);
                    }
                }
            }

            return sortedItems;
        }

        #endregion

        #region Heap

        static T[] HeapSort<T>(T[] items) where T : IComparable<T>
        {
            var heap = new Heap<T>();

            foreach (var item in items)
            {
                heap.Push(item);
            }

            T[] sortedItems = new T[heap.Count];
            for (int i = 0; i < sortedItems.Length; i++)
            {
                sortedItems[i] = heap.Pop();
            }
            return sortedItems;
        }

        #endregion


        static void Main()
        {
            int count = 55000;
            DateTime start, end;

            int[] items = GetArrayToSort(count);
            Console.WriteLine("Sorting {0} values", count);

            start = DateTime.Now;
            Console.WriteLine("With built-in sort: ");
            var sortedItemsWithBuiltInSort = items.OrderBy(number => number);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithBuiltInSort));

            start = DateTime.Now;
            Console.WriteLine("With QuickSort: ");
            var sortedItemsWithQuickSort = QuickSort(items);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithQuickSort));

            start = DateTime.Now;
            Console.WriteLine("With MergeSort: ");
            var sortedItemsWithMergeSort = MergeSort(items);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithMergeSort));


            start = DateTime.Now;
            Console.WriteLine("With HeapSort: ");
            var sortedItemsWithHeapSort = HeapSort(items);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithHeapSort));

            start = DateTime.Now;
            Console.WriteLine("With BubbleSort: ");
            var sortedItemsWithBubbleSort = BubbleSort(items);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithBubbleSort));

            start = DateTime.Now;
            Console.WriteLine("With SelectionSort: ");
            var sortedItemsWithSelectionSort = SelectionSort(items);
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
            Console.WriteLine("Are sorted? -> {0}", IsSorted(sortedItemsWithSelectionSort));
        }

        static Random rand = new Random();

        private static bool IsSorted(IEnumerable<int> sortedSequence)
        {
            var sequence = sortedSequence.ToArray();
            var prev = sequence[0];
            for (int i = 1; i < sequence.Length; i++)
            {
                var next = sequence[i];
                if (prev > next)
                {
                    return false;
                }
                prev = next;
            }
            return true;
        }

        private static int[] GetArrayToSort(int count)
        {
            return Enumerable.Range(1, count)
                //.Reverse()
                .Select(index => rand.Next(1000))
                .ToArray();
        }
    }
}