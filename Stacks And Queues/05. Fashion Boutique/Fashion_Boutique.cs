using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Fashion_Boutique
    {
        static void Main(string[] args)
        {

            Stack<int> boxOfClotheStack = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray());
            int rackSize = int.Parse(Console.ReadLine());

            int noOfRacks = 0, currentSize = 0;

            while (boxOfClotheStack.Count > 0)
            {
                currentSize += boxOfClotheStack.Peek();

                if (currentSize <= rackSize)
                {
                    boxOfClotheStack.Pop();

                    if (boxOfClotheStack.Count == 0)
                    {
                        noOfRacks++;
                    }

                }
                else
                {
                    noOfRacks++;
                    currentSize = 0;
                }
            }

            Console.WriteLine(noOfRacks);
        }
    }
}
