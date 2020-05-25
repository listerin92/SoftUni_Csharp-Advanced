using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Fast_Food
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            Queue<int> quantityOfOrder = new Queue<int>(Console.ReadLine()
                .Split(' ',
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(Int32.Parse)
                .ToArray());

            int maxOrder = quantityOfOrder.Max();

            while (quantityOfOrder.Count > 0)
            {

                int currentOrder = quantityOfOrder.Peek();
                if (quantity >= currentOrder)
                {
                    quantity -= currentOrder;
                    quantityOfOrder.Dequeue();
                }
                else
                {
                    break;
                }
            }


            Console.WriteLine(maxOrder);

            if (quantityOfOrder.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: {0}", string.Join(' ', quantityOfOrder.ToArray()));
            }
        }
    }
}
