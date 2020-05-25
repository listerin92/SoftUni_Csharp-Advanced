using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Unique_Usernames
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string names = Console.ReadLine();
                uniqueNames.Add(names);
            }
            foreach (var names in uniqueNames)
            {
                Console.WriteLine(names);
            }
        }
    }
}
