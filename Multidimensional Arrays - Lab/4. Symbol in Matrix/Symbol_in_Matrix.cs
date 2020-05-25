using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Symbol_in_Matrix
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int rows = input;
            int cols = input;
            char[,] two2arr = new char[rows, cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                char[] collumn = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    two2arr[i, j] = collumn[j];
                    
                }
            }
            char lookFor = char.Parse(Console.ReadLine());
            string found = string.Empty;
            string notFound = string.Empty;

            for (int i = 0; i < two2arr.GetLength(0); i++)
            {
                if (found != String.Empty)
                {
                    break;
                }
                for (int j = 0; j < two2arr.GetLength(1); j++)
                {
                    if (lookFor == two2arr[i,j])
                    {
                        found = ($"({i}, {j})");
                        break;
                    }
                    else
                    {
                        notFound = ($"{lookFor} does not occur in the matrix ");
                    }
                }
            }

            if (found != String.Empty)
            {
                Console.WriteLine(found);
            }
            else
            {
                Console.WriteLine(notFound);

            }
        }
    }
}
