using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Applied_Arithmetics
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> addFunc = x => x.Select(a => a += 1).ToList();
            Func<List<int>, List<int>> subtractFunc = x => x.Select(a => a -= 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = x => x.Select(a => a *= 2).ToList();
            Action<List<int>> Print = x => Console.WriteLine(string.Join(" ", x));
            var numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
            string operation = Console.ReadLine();

            while (true)
            {
                if (operation == "end")
                {
                    break;
                }

                switch (operation)
                {
                    case "add":
                        numbers = addFunc(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyFunc(numbers);
                        break;
                    case "subtract":
                        numbers = subtractFunc(numbers);
                        break;
                    case "print":
                        Print(numbers);
                        break;
                    default:
                        Console.WriteLine("Something's wrong!");
                        break;
                }
                operation = Console.ReadLine();

            }
        }
    }
}
