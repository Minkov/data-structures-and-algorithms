namespace Heap
{
    using System;

    public class HeapTest
    {
        public static void Main(string[] args)
        {
            var heap = new Heap<int>((x, y) => y - x);

            heap.Push(10);
            heap.Push(13);
            heap.Push(6);
            heap.Push(1);
            Console.WriteLine(heap.Peek());
        }
    }
}
