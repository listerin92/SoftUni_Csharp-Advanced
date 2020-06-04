using System;

namespace Create_Custom_Data_Structures
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var stack = new CoolStack<int>();
            //stack.Push(2);
            //stack.Push(5);
            //stack.Push(10);

            //Console.WriteLine(stack.Count == 3);
            //var value = stack.Pop(2);

            //Console.WriteLine(stack.Count == 2);
            //stack.ForEach(x => Console.WriteLine(x));


            var linkedList = new LinkedList<int>();

            linkedList.AddHead(5);
            linkedList.AddHead(10);
            linkedList.AddHead(15);
            Console.WriteLine(linkedList.Head == 15);
            Console.WriteLine(linkedList.Tail == 5);
            Console.WriteLine(linkedList.Count == 3);
            linkedList.AddTail(20);
            linkedList.AddTail(25);

            linkedList.ForEach(Console.WriteLine, reverse: true);
            var array = linkedList.ToArray();

            foreach (var arr in array)
            {
                Console.WriteLine(arr);
            }
            Console.WriteLine(linkedList.Head == 15);
            Console.WriteLine(linkedList.Tail == 25);
            Console.WriteLine(linkedList.RemoveHead() == 15);
            Console.WriteLine(linkedList.RemoveHead() == 10);
            Console.WriteLine(linkedList.Head == 5);
            Console.WriteLine(linkedList.Count == 3);
            Console.WriteLine(linkedList.RemoveTail() == 25);
            Console.WriteLine(linkedList.RemoveTail() == 20);
            Console.WriteLine(linkedList.RemoveTail() == 5);
            Console.WriteLine(linkedList.Count == 0);

            try
            {
                Console.WriteLine(linkedList.Head);
                Console.WriteLine(false);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(true);
            }

            linkedList = new LinkedList<int>();
            linkedList.AddTail(5);
            linkedList.AddTail(10);
            linkedList.AddTail(5);
            linkedList.AddTail(20);
            linkedList.AddTail(5);
            linkedList.Remove(5);
            Console.WriteLine(linkedList.Head == 10);
            Console.WriteLine(linkedList.Tail == 20);
            Console.WriteLine(linkedList.Contains(10));
            Console.WriteLine(linkedList.Contains(20));
            Console.WriteLine(linkedList.Contains(5) == false);
            Console.WriteLine(linkedList.Count == 2);
            linkedList.Clear();

            Console.WriteLine(linkedList.Count == 0);
            Console.WriteLine(linkedList.Contains(10) == false);
            Console.WriteLine(linkedList.Contains(20) == false);
        }
    }
}
