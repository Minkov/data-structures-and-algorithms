using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(5);
            tree.Add(15);
            tree.Add(25);
            tree.Add(2);
            tree.Add(10);

            foreach (var node in tree)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("---------------");

            Console.WriteLine("Has {0} -> {1}", 15, tree.Contains(15));
            Console.WriteLine("Has {0} -> {1}", 5, tree.Contains(5));
            Console.WriteLine("Has {0} -> {1}", 25, tree.Contains(25));
            Console.WriteLine("Has {0} -> {1}", 32, tree.Contains(32));
        }
    }
}
