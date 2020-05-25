using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Squares_in_Matrix
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] arr = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] column = Console.ReadLine().Split(" ").ToArray();
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = column[j];
                }
            }

            int existCount = 0;
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    string tempCharCandidate = arr[i, j];

                    if (tempCharCandidate == arr[i, j]
                        && tempCharCandidate == arr[i, j + 1]
                        && tempCharCandidate == arr[i + 1, j]
                        && tempCharCandidate == arr[i + 1, j + 1])
                    {
                        existCount++;
                    }

                }
            }
            Console.WriteLine(existCount);
        }
    }
}
