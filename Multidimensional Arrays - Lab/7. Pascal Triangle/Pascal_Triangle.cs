using System;

namespace _7._Pascal_Triangle
{
    class Pascal_Triangle
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rows][];
            int currentLength = 1;
            for (int i = 0; i < rows; i++)
            {
                triangle[i] = new long[currentLength];
                triangle[i][0] = 1;
                triangle[i][currentLength - 1] = 1;

                if (currentLength > 2)
                {
                    for (int j = 1; j < currentLength - 1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }

                currentLength++;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
