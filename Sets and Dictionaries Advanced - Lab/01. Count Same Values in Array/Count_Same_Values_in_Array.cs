using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Count_Same_Values_in_Array
    {
        static void Main(string[] args)
        {

            double[] number = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> dict = CounterDict(number);

            foreach (var num in dict)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }

        static Dictionary<double, int> CounterDict(double[] number)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();

            foreach (var num in number)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict[num] = 1;
                }
            }
            return dict;
        }
    }
}