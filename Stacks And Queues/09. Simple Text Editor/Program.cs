using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> previousCommands = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                string command = cmd[0];
                switch (command)
                {
                    case "1":
                        previousCommands.Push(text);
                        string textToAppend = cmd[1];
                        text += textToAppend;
                        break;

                    case "2":
                        previousCommands.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(cmd[1]));
                        break;

                    case "3":
                        Console.WriteLine(text[int.Parse(cmd[1]) - 1]);
                        break;

                    case "4":
                        text = previousCommands.Pop();
                        break;
                }
            }
        }
    }
}