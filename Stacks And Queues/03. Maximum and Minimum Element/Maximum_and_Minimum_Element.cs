using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _03._Maximum_and_Minimum_Element
{
    class Maximum_and_Minimum_Element
    {
        static void Main(string[] args)
        {
            int nQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            List<int> whatToPrint = new List<int>();

            for (int i = 0; i < nQueries; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                int command = tokens[0];
                switch (command)
                {
                    case 1:
                        {
                            int element = tokens[1];
                            stack.Push(element);
                            break;
                        }
                    case 2:
                        {
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                            }
                            break;
                        }
                    case 3:
                        {
                            if (stack.Count > 0)
                            {
                                whatToPrint.Add(stack.Max());
                            }
                            break;
                        }
                    case 4:
                        {
                            if (stack.Count > 0)
                            {
                                whatToPrint.Add(stack.Min());
                            }
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("!!!!!!!!!!!!");
                        }
                }
            }

            foreach (var item in whatToPrint)
            {
                Console.WriteLine(item);
            }
            Console.Write(string.Join(", ", stack.ToArray()));


        }
    }
}
