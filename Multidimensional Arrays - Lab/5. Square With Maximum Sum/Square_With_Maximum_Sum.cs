using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Square_With_Maximum_Sum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] two2arr = new int[rows, cols];
            int maxSum = int.MinValue;
            int maxSumCol = -1;
            int maxSumRow = -1;
            for (int i = 0; i < rows; i++)
            {
                int[] collumn = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    two2arr[i, j] = collumn[j];
                }
            }

            for (int i = 0; i < two2arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < two2arr.GetLength(1)-1; j++)
                {
                    int sum = two2arr[i, j];
                    sum += two2arr[i, j + 1];
                    sum += two2arr[i + 1, j];
                    sum += two2arr[i + 1, j + 1];
                    
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumCol = i;
                        maxSumRow = j;
                    }
                }
            }

            Console.WriteLine($"{two2arr[maxSumCol, maxSumRow]} {two2arr[maxSumCol, maxSumRow+1]}");
            Console.WriteLine($"{two2arr[maxSumCol+1, maxSumRow]} {two2arr[maxSumCol+1, maxSumRow + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
