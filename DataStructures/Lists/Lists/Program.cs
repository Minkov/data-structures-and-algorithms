using System;

namespace Lists
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int count = 100;
			var numbers = new DoubleLinkedList<int> ();

			for (int i = 0; i < count; i++) 
			{
				numbers.AddLast (i);
			}

			foreach (var number in numbers) 
			{
				Console.WriteLine (number);
			}
		}
	}
}
