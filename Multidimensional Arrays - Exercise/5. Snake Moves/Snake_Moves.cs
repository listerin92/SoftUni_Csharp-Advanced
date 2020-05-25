using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Snake_Moves
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] arr = new char[rows, cols];
            char[] column = Console.ReadLine().ToCharArray();
            Queue<char> snake = new Queue<char>(column);

            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        char ch = snake.Dequeue();
                        arr[i, j] = ch;
                        snake.Enqueue(ch);
                    }
                }
                else
                {
                    for (int j = cols-1; j >= 0; j--)
                    {
                        char ch = snake.Dequeue();
                        arr[i, j] = ch;
                        snake.Enqueue(ch);
                    }
                }
                
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
