using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class StacksTester
    {
        static void Main()
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i + 1);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
