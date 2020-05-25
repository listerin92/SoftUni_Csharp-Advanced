using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Record_Unique_Names
{
    class Record_Unique_Names
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
