using System;
using System.Linq;
using System.Collections.Generic;

namespace MaxIncreasingSequence
{
	class MainClass
	{
		static int[] FindMaxNonDecreasingSequence(int[] arr)
		{
			int[] sequencesCount = new int[arr.Length];
			int[] paths = Enumerable.Repeat (-1, arr.Length).ToArray ();

			for (int i = 0; i < arr.Length; i++) {
				for (int j = 0; j < i; j++) {
					if (arr [j] <= arr [i]) {
						var newSequenceLength = sequencesCount [j] + 1;
						if (sequencesCount [i] < newSequenceLength) {
							paths [i] = j;
							sequencesCount [i] = newSequenceLength;
						}
					}
				}
			}

			int maxSequenceLength = sequencesCount [0];
			int pathStart = 0;


			for (int i = 0; i < sequencesCount.Length; i++) {
				if (maxSequenceLength < sequencesCount [i]) 
				{
					maxSequenceLength = sequencesCount [i];
					pathStart = i;
				}
			}
			Console.WriteLine (maxSequenceLength);
			Console.WriteLine (pathStart);

			var index = pathStart;
			var maxNonDecreasingSequence = new int[maxSequenceLength + 1];
			int position = maxNonDecreasingSequence.Length - 1;
			while (index != -1) {
				maxNonDecreasingSequence [position] = arr [index];
				index = paths [index];
				--position;
			}
			return maxNonDecreasingSequence;
		}

		public static void Main (string[] args)
		{
			int[] arr = { 1, 2, 5, 3, 6, 4, 5, 8, 6, 7 };

			var sequence = FindMaxNonDecreasingSequence (arr);
			Console.WriteLine (string.Join(", ", sequence));
		}
	}
}
