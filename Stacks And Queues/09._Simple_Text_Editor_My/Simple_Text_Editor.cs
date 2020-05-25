using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Simple_Text_Editor
    {
        static void Main(string[] args)
        {
            int noOfLines = int.Parse(Console.ReadLine());
            Queue<char> textStack = new Queue<char>();
            Stack<string> undoStackString = new Stack<string>(new string[1] {"\0"});


            for (int i = 0; i < noOfLines; i++)
            {
                string[] line = Console.ReadLine().Split(" ").ToArray();
                string command = line[0];

                switch (command)
                {
                    case "1":
                        {
                            char[] text = line[1].ToCharArray();
                            StringBuilder wholeText = new StringBuilder();

                            foreach (var item in text)
                            {
                                textStack.Enqueue(item);
                                wholeText.Append(item);
                            }

                            undoStackString.Push(wholeText.ToString());


                            break;
                        }
                    case "2":
                        {
                            int eraseCount = int.Parse(line[1]);
                            StringBuilder wholeText = new StringBuilder();

                            for (int j = 0; j < eraseCount; j++)
                            {
                                textStack.Dequeue();
                            }

                            Stack<char> textStackCopy = new Stack<char>(textStack.Reverse());
                            for (int k = 0; k < textStackCopy.Count; k++)
                            {
                                wholeText.Append(textStackCopy.Peek());
                            }
                            undoStackString.Push(wholeText.ToString());

                            break;
                        }
                    case "3":
                        {
                            int indexToReturn = int.Parse(line[1]);
                            Console.WriteLine(textStack.ToArray()[indexToReturn - 1]);
                            break;
                        }
                    case "4":
                        {
                            string lastItem = undoStackString.Pop();
                            string beforeLast = undoStackString.Peek();
                            if (undoStackString.Any() && (undoStackString.Peek() != ""))
                            {
                                foreach (var item in beforeLast)
                                {
                                    textStack.Enqueue(item);
                                }
                                undoStackString.Push(lastItem);
                            }
                            else
                            {
                                textStack.Clear();
                            }
                            break;
                        }
                }
            }
        }
    }
}