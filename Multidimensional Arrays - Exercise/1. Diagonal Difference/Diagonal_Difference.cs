using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Diagonal_Difference
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int rowscols = input;
            int[,] two2arr = new int[rowscols, rowscols];
            int primary = 0, secondary = 0;
            for (int i = 0; i < rowscols; i++)
            {
                int[] column = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < rowscols; j++)
                {
                    two2arr[i, j] = column[j];
                    if (i == j)
                    {
                        primary += two2arr[i, j];
                    }

                    if ((i+j) == (rowscols - 1))
                    {
                        secondary += two2arr[i, j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primary-secondary));
        }
    }
}
