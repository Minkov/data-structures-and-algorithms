namespace Heap
{
    using System;
    using System.Collections.Generic;

    public class HeapTest
    {
        public static void Main(string[] args)
        {
            var heap = new Heap<int>();

            var count = 55;
            var sequence = new List<int>();
            for (int i = 0; i < count; i++)
            {
                heap.Push(count - i);
            }

            heap.Print();

            int index = 0;
            while (heap.Count > 0)
            {
                ++index;
                sequence.Add(heap.Pop());
            }

            var prev = sequence[0];
            for (int i = 1; i < sequence.Count; i++)
            {
                var next = sequence[i];
                if (prev <= next)
                {
                    Console.WriteLine("{0} <= {1}", prev, next);
                }
                else
                {
                    Console.WriteLine("---Wrong: {0} > {1}", prev, next);
                }

                prev = next;
            }
        }
    }
}
