using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Maximal_Sum
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
            int[,] arr = new int[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] column = Console.ReadLine()
                    .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columnsCount; col++)
                {
                    arr[row, col] = column[col];
                }
            }


            long maxSum = 0;
            int rowStartIndex = 0, colStartIndex = 0;
            
            for (int row = 0; row < arr.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < arr.GetLength(1) - 2; col++)
                {
                    long sum = CalculateSumForSize(arr, row, col, 3);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowStartIndex = row;
                        colStartIndex = col;
                    }
                }
            }
                              
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{arr[rowStartIndex, colStartIndex]} " +
                              $"{arr[rowStartIndex, colStartIndex + 1]} " +
                              $"{arr[rowStartIndex, colStartIndex + 2]}");

            Console.WriteLine($"{arr[rowStartIndex + 1, colStartIndex]} " +
                              $"{arr[rowStartIndex + 1, colStartIndex + 1]} " +
                              $"{arr[rowStartIndex + 1, colStartIndex + 2]}");

            Console.WriteLine($"{arr[rowStartIndex + 2, colStartIndex]} " +
                              $"{arr[rowStartIndex + 2, colStartIndex + 1]} " +
                              $"{arr[rowStartIndex + 2, colStartIndex + 2]}");
            // bellow one not work because of the space after arr[row, col]
            /*for (int row = rowStartIndex; row < rowStartIndex + 3; row++)
            {
                for (int col = colStartIndex; col < colStartIndex + 3; col++)
                {
                    Console.Write($"{arr[row, col]} ");
                }

                Console.WriteLine();
            }*/
        }

        static long CalculateSumForSize(int[,] arr, int row, int col, int size)
        {
            long sum = 0;
            for (int i = row; i < row + size; i++)
            {
                for (int j = col; j < col + size; j++)
                {
                    sum += arr[i, j];
                }
            }
            return sum;
        }
    }
}
