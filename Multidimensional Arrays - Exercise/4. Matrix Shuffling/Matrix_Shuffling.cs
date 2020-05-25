using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Matrix_Shuffling
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowsCount = input[0];
            int columnsCount = input[1];
            string[,] arr = new string[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {

                string[] column = Console.ReadLine()
                    .Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < columnsCount; col++)
                {
                    arr[row, col] = column[col];
                }
            }

            List<string> cmd = new List<string>();
            cmd = Console.ReadLine().Split(' ').ToList();

            while (cmd[0] != "END")
            {
                if (cmd[0] == "swap" && cmd.Count == 5)
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);
                    int maxRowIndex = arr.GetLength(0) - 1;
                    int maxColIndex = arr.GetLength(1) - 1;

                    if (row1 >= 0 && row1 <= maxRowIndex
                                  && col1 >= 0 && col1 <= maxColIndex
                                  && row2 >= 0 && row2 <= maxRowIndex
                                  && col2 >= 0 && col2 <= maxColIndex
                                  && cmd.Count == 5)
                    {
                        string temp = arr[row1, col1];
                        arr[row1, col1] = arr[row2, col2];
                        arr[row2, col2] = temp;
                        PrintArray(arr);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                cmd = Console.ReadLine().Split(' ').ToList();
            }
        }

        private static void PrintArray(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }

                Console.WriteLine();
            }

        }
    }
}
