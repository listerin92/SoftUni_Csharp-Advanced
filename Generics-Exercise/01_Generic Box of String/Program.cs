using System;
using System.Collections.Generic;

namespace _01_Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {

            int length = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < length; i++)
            {
                string lines = Console.ReadLine();
                Box<string> newStr = new Box<string>(lines);
                Console.WriteLine(newStr.ToString());

            }

        }
    }
}
