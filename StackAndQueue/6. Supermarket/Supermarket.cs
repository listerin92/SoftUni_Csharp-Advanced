using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> inputQueue = new Queue<string>();
            Queue<string> outputQueue = new Queue<string>();
            string cmd = string.Empty;
            while ((cmd = Console.ReadLine()) != "End")
            {
                inputQueue.Enqueue(cmd);

                if (cmd == "Paid")
                {
                    while (inputQueue.Count > 1)
                    {
                        outputQueue.Enqueue(inputQueue.Dequeue());

                    }
                    inputQueue.Clear();
                }
            }
            while (outputQueue.Count > 0)
            {
                Console.WriteLine(outputQueue.Dequeue());
            }
            Console.WriteLine($"{inputQueue.Count} people remaining.");
        }
    }
}
