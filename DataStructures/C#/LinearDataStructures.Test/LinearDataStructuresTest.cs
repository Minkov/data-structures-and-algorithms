namespace LinearDataStructures.Test
{
    using System;
    using Extensions;

    class LinearDataStructuresTest
    {
        static void Main()
        {
            TestList();
            TestQueue();
            TestStack();
        }

        private static void TestStack()
        {
            Console.WriteLine(value: "Testing the Stack");

            var stack = new Stack<int>();

            int count = 10;
            for (int i = 0; i < count; i++)
            {
                stack.Push(i + 1);
            }

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
        } 

        private static void TestQueue()
        {
            Console.WriteLine(value: "Testing the Queue");
            var queue = new Queue<int>();

            int count = 10;
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(i + 1);
            }

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void TestList()
        {
            Console.WriteLine(value: "Testing the List");
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            while (!list.IsEmpty())
            {
                Console.WriteLine(list.First);
                list.RemoveFirst();
            }

            //Console.WriteLine(list.First);
        }
    }
}
