using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
	class Program
	{
		static void Swap<T> (T[] items, int i, int j)
		{
			var temp = items [i];
			items [i] = items [j];
			items [j] = temp;
		}

		#region QuickSort

		static T[] QuickSort<T> (T[] items) where T : IComparable<T>
		{
			var toBeSortedItems = items.Select (x => x).ToArray ();
			QuickSort (toBeSortedItems, 0, toBeSortedItems.Length - 1);
			return toBeSortedItems;
		}

		static void QuickSort<T> (T[] items, int start, int end) where T : IComparable<T>
		{
			if (start < end) {
				int partition = Partition (items, start, end);
				QuickSort (items, start, partition - 1);
				QuickSort (items, partition + 1, end);
			}
		}

		private static int Partition<T> (T[] items, int start, int end) where T : IComparable<T>
		{
			var pivot = start;
			var value = items [pivot];
		
			//swap
			Swap (items, pivot, end);

			var index = start;
			for (int i = start; i <= end; i++) {
				if (items [i].CompareTo (value) < 0) {
					Swap (items, i, index);
					++index;
				}
			}
			Swap (items, index, end);
			return index;
		}

		#endregion

		#region MergeSort

		private static T[] MergeSort<T> (T[] items) where T : IComparable<T>
		{
			var toBeSortedItems = items.Select (x => x).ToArray ();

			T[] tempArray = new T[items.Length];
			MergeSort (toBeSortedItems, 0, toBeSortedItems.Length - 1, tempArray);

			return toBeSortedItems;
		}

		private static void MergeSort<T> (T[] items, int from, int to, T[] tempArray) where T : IComparable<T>
		{
			if (from < to) {
				int middle = (from + to) / 2;
				MergeSort (items, from, middle, tempArray);
				MergeSort (items, middle + 1, to, tempArray);
				Merge (items, from, to, tempArray);
			}
		}

		private static void Merge<T> (T[] items, int from, int to, T[] tempArray) where T : IComparable<T>
		{
			int middle = (from + to) / 2;

			int left = from;
			int right = middle + 1;
			int pos = from;

			while ((left <= middle) && (right <= to)) {
				if (items [left].CompareTo (items [right]) < 0) {
					tempArray [pos] = items [left];
					++left;
				} else {
					tempArray [pos] = items [right];
					++right;
				}
				++pos;
			}

			while (left <= middle) {
				tempArray [pos] = items [left];
				++pos;
				++left;
			}
			while (right <= to) {
				tempArray [pos] = items [right];
				++pos;
				++right;
			}

			for (int i = from; i <= to; i++) {
				items [i] = tempArray [i];
			}
		}

		#endregion

		#region BubbleSort

		static T[] BubbleSort<T> (T[] items) where T : IComparable<T>
		{
			T[] sortedItems = (T[])items.Clone ();

			bool isSwapDone = false;
			do {
				isSwapDone = false;
				for (int j = 0; j < sortedItems.Length - 1; j++) {
					if (sortedItems [j].CompareTo (sortedItems [j + 1]) > 0) {
						isSwapDone = true;
						Swap(sortedItems, j, j +1);
					}
				}
			} while (isSwapDone);

			return sortedItems;
		}

		#endregion

		#region SelectionSort

		static T[] SelectionSort<T> (T[] items) where T : IComparable<T>
		{
			var sortedItems = (T[])items.Clone ();

			for (int i = 0; i < sortedItems.Length; i++) {
				for (int j = sortedItems.Length - 1; j > i; j--) {
					if (sortedItems [i].CompareTo (sortedItems [j]) > 0) {
						Swap (sortedItems, i, j);
					}
				}
			}

			return sortedItems;
		}

		#endregion

		static Random rand = new Random ();

		static void Main ()
		{
			int count = 10;
			DateTime start, end;

			int[] items = Enumerable.Range (1, count).Reverse ().ToArray ();
			//int[] items = new int[count];

			//for (int i = 0; i < items.Length; i++)
			//{
			//    items[i] = rand.Next();
			//}

            start = DateTime.Now;
            Console.WriteLine("With built-in sort: ");
            var sortedItemsWithBuiltInSort = items.OrderBy(number => number);
            //Console.WriteLine(string.Join(", ", sortedItemsWithBuiltInSort));
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);

			start = DateTime.Now;
			var sortedItemsWithQuickSort = QuickSort (items);
			Console.WriteLine ("With QuickSort: ");
			Console.WriteLine (string.Join (", ", sortedItemsWithQuickSort));
			end = DateTime.Now;
			Console.WriteLine ("Finished in {0} seconds", end - start);

            start = DateTime.Now;
            var sortedItemsWithMergeSort = MergeSort(items);
            Console.WriteLine("With MergeSort: ");
			//Console.WriteLine(string.Join(", ", sortedItemsWithMergeSort));
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);

            start = DateTime.Now;
            var sortedItemsWithBubbleSort = BubbleSort(items);
            Console.WriteLine("With BubbleSort: ");
			//Console.WriteLine(string.Join(", ", sortedItemsWithBubbleSort));
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);

            start = DateTime.Now;
            var sortedItemsWithSelectionSort = SelectionSort(items);
            Console.WriteLine("With SelectionSort: ");
			//Console.WriteLine(string.Join(", ", sortedItemsWithSelectionSort));
            end = DateTime.Now;
            Console.WriteLine("Finished in {0} seconds", end - start);
		}
	}
}