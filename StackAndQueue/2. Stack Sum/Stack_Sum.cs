using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Stack_Sum
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray());
            string cmd = string.Empty;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = cmd.Split(" ").ToArray();
                string command = tokens[0].ToLower();
                switch (command)
                {
                    case "add":
                        {
                            int opp1 = int.Parse(tokens[1]);
                            int opp2 = int.Parse(tokens[2]);
                            stack.Push(opp1);
                            stack.Push(opp2);
                            break;
                        }
                    case "remove":
                        {
                            int opp1 = int.Parse(tokens[1]);
                            if (stack.Count > opp1)
                            {
                                for (int i = 0; i < opp1; i++)
                                {
                                    stack.Pop();
                                }
                            }
                            break;
                        }
                    default:
                        throw new ArgumentException("Unknown command!");
                }
            }

            int sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
