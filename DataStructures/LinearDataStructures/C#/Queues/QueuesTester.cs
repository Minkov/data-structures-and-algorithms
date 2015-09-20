using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class QueuesTester
    {
        static void Main()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            for (int i = 0; i < 15; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
