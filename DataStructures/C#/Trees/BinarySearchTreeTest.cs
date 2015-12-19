using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinarySearchTreeTest
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(5);
            tree.Add(15);
            tree.Add(25);
            tree.Add(2);
            tree.Add(10);

            Console.WriteLine("Whole tree:");
            tree.ForEach(Console.WriteLine);

            Console.WriteLine("Count: {0}", tree.Count);
            Console.WriteLine("Min: {0}", tree.Min);
            Console.WriteLine("Max: {0}", tree.Max);

            Console.WriteLine("Smaller than 5 (inclusive):");
            tree.GetSmallerThan(5)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Smaller than 5 (exclusive):");
            tree.GetSmallerThan(5, true)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Bigger than 5 (inclusive):");
            tree.GetBiggerThan(5)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Bigger than 5 (exclusive):");
            tree.GetBiggerThan(5, true)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Between 5 and 15 (inclusive):");
            tree.GetRangeBetween(5, 15)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Between 5 and 15 (exclusive):");
            tree.GetRangeBetween(5, 15, true)
                    .ForEach(Console.WriteLine);

            Console.WriteLine("Between 1 and 15 (inclusive):");
            tree.GetRangeBetween(1, 15)
                    .ForEach(Console.WriteLine);
        }
    }
}
