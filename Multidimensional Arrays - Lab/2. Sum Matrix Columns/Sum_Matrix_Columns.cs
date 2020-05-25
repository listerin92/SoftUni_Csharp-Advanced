using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Sum_Matrix_Columns
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] two2arr = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] collumn = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    two2arr[i, j] = collumn[j];
                }
            }

            for (int i = 0; i < two2arr.GetLength((1)); i++)
            {
                int sum = 0;
                for (int j = 0; j < two2arr.GetLength(0); j++)
                {
                    sum += two2arr[j, i];
                }

                Console.WriteLine(sum);
                ;
            }
        }
    }
}
