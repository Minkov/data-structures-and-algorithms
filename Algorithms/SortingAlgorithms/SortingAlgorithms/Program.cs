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

		private static T[] MergeSort<T> (T[] numbers) where T : IComparable<T>
		{
			var sortedNumbers = numbers.Select (x => x).ToArray ();

			T[] tempArray = new T[numbers.Length];
			MergeSort (sortedNumbers, 0, sortedNumbers.Length - 1, tempArray);

			return sortedNumbers;
		}

		private static void MergeSort<T> (T[] numbers, int from, int to, T[] tempArray) where T : IComparable<T>
		{
			if (from < to) {
				int middle = (from + to) / 2;
				MergeSort (numbers, from, middle, tempArray);
				MergeSort (numbers, middle + 1, to, tempArray);
				Merge (numbers, from, to, tempArray);
			}
		}

		private static void Merge<T> (T[] numbers, int from, int to, T[] tempArray) where T : IComparable<T>
		{
			int middle = (from + to) / 2;

			int left = from;
			int right = middle + 1;
			int pos = from;

			while ((left <= middle) && (right <= to)) {
				if (numbers [left].CompareTo (numbers [right]) < 0) {
					tempArray [pos] = numbers [left];
					++left;
				} else {
					tempArray [pos] = numbers [right];
					++right;
				}
				++pos;
			}

			while (left <= middle) {
				tempArray [pos] = numbers [left];
				++pos;
				++left;
			}
			while (right <= to) {
				tempArray [pos] = numbers [right];
				++pos;
				++right;
			}

			for (int i = from; i <= to; i++) {
				numbers [i] = tempArray [i];
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
						var temp = sortedItems [j];
						sortedItems [j] = sortedItems [j + 1];
						sortedItems [j + 1] = temp;
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
						var temp = sortedItems [i];
						sortedItems [i] = sortedItems [j];
						sortedItems [j] = temp;
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

			int[] numbers = Enumerable.Range (1, count).Reverse ().ToArray ();
			//int[] numbers = new int[count];

			//for (int i = 0; i < numbers.Length; i++)
			//{
			//    numbers[i] = rand.Next();
			//}

//            start = DateTime.Now;
//            Console.WriteLine("With built-in sort: ");
//            var sortedNumbersWithBuiltInSort = numbers.OrderBy(number => number);
//            //Console.WriteLine(string.Join(", ", numbers));
//            end = DateTime.Now;
//            Console.WriteLine("Finished in {0} seconds", end - start);

			start = DateTime.Now;
			var sortedNumbersWithQuickSort = QuickSort (numbers);
			Console.WriteLine ("With QuickSort: ");
			Console.WriteLine (string.Join (", ", sortedNumbersWithQuickSort));
			end = DateTime.Now;
			Console.WriteLine ("Finished in {0} seconds", end - start);

//            start = DateTime.Now;
//            var sortedNumbersWithMergeSort = MergeSort(numbers);
//            Console.WriteLine("With MergeSort: ");
//            //Console.WriteLine(string.Join(", ", sortedNumbersWithMergeSort));
//            end = DateTime.Now;
//            Console.WriteLine("Finished in {0} seconds", end - start);
//
//            start = DateTime.Now;
//            var sortedNumbersWithBubbleSort = BubbleSort(numbers);
//            Console.WriteLine("With BubbleSort: ");
//            //Console.WriteLine(string.Join(", ", sortedNumbersWithBubbleSort));
//            end = DateTime.Now;
//            Console.WriteLine("Finished in {0} seconds", end - start);
//
//            start = DateTime.Now;
//            var sortedNumbersWithSelectionSort = SelectionSort(numbers);
//            Console.WriteLine("With SelectionSort: ");
//            //Console.WriteLine(string.Join(", ", sortedNumbersWithSelectionSort));
//            end = DateTime.Now;
//            Console.WriteLine("Finished in {0} seconds", end - start);
		}
	}
}