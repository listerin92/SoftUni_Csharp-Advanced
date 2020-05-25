using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Sum_Matrix_Elements
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int col = input[1];
            int[,] two2arr = new int[rows,col];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] collumn = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    two2arr[i, j] = collumn[j];
                    sum += two2arr[i, j];
                }
            }

            Console.WriteLine(two2arr.GetLength(0));
            Console.WriteLine(two2arr.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
