using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Stack<string> stk = new Stack<string>();
            while (command != "END")
            {
                try
                {

                    var cmd = command.Split(' ').Take(1).ToArray();
                    if (cmd[0] == "Push")
                    {
                        var tmp = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

                        for (int i = 0; i < tmp.Length; i++)
                        {
                            stk.Push(tmp[i]);
                        }
                    }
                    else if (cmd[0] == "Pop")
                    {
                        stk.Pop();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                command = Console.ReadLine();
            }

            foreach (var s in stk)
            {
                Console.WriteLine(s);
            }
        }
    }
}
