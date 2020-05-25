using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Primary_Diagonal
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int rows = input;
            int cols = input;
            int[,] two2arr = new int[rows, cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] collumn = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    two2arr[i, j] = collumn[j];
                    if (i == j)
                    {
                        sum += two2arr[i, j];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
