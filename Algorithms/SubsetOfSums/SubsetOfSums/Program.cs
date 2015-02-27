using System;
using System.Linq;
using System.Collections.Generic;

namespace SubsetOfSums
{
	class MainClass
	{
		static bool CanSumBeReached (int[] values, long s)
		{
			bool[] sumsFound = new bool[s + 1];
			sumsFound [0] = true;
			bool isSumFound = false;
			foreach (var value in values) {
				if (isSumFound) {
					break;
				}
				for (long i = s - 1; i >= 0; i--) {
					if (sumsFound [i]) {
						if (i + value > s) {
							continue;
						}
						sumsFound [i + value] = true;
					}
					if (sumsFound [s]) {
						return true;
					}
				}
			}
			return false;
		}

		static bool CanSumBeReachedWithSets(int[] values, int s){
			HashSet<long> sums = new HashSet<long> ();
			sums.Add (0);
			HashSet<long> sumsForValue = new HashSet<long> ();
			foreach (var value in values) {
				sumsForValue.Clear ();
				foreach (var sum in sums) {
					var newSum = sum + value;
					if (newSum == s) {
						return true;
					}
					sumsForValue.Add (newSum);
				}
				foreach (var sum in sumsForValue) {
					sums.Add (sum);
				}
			}

			return false;
		}

		public static void Main (string[] args)
		{
			int count = 1000;
			int[] values = Enumerable.Range (1, count).ToArray ();
			int s = 1000000;
			DateTime start, end;

			start = DateTime.Now;

			bool isSumBeReached = CanSumBeReached (values, s);
			end = DateTime.Now;

			Console.WriteLine ("Reached? -> {0}", isSumBeReached);
			Console.WriteLine ("Finished in {0} seconds", end-start);

			start = DateTime.Now;
			isSumBeReached = CanSumBeReachedWithSets(values, s);
			end = DateTime.Now;
			Console.WriteLine ("Reached? -> {0}", isSumBeReached);
			Console.WriteLine ("Finished in {0} seconds", end-start);
		}
	}
}
