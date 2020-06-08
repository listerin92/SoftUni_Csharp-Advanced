using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listyIterator = null;
            while (command != "END")
            {
                try
                {
                    if (command.Contains("Create"))
                    {
                        List<string> commandArray = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(commandArray);
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (command == "Print")
                    {
                        listyIterator.Print();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
