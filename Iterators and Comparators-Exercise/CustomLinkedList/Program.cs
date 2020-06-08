using System;

namespace CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> ints = new LinkedList<int>();
            ints.AddTail(5);
            ints.AddTail(6);
            ints.AddTail(10);
            ints.AddTail(12);
            ints.AddTail(1);
            ints.AddTail(100);

            foreach (var i in ints)
            {
                Console.WriteLine(i);
            }
        }
    }
}
