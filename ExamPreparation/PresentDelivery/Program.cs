using System;
using System.Linq;

namespace PresentDelivery
{
    public class Santa
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int NiceKidsCount { get; set; }
        public int Presents { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Santa santa = new Santa();
            santa.Presents = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            
            FillMatrix(matrixSize, matrix, santa);
            int initialKidCount = santa.NiceKidsCount;
            string command = Console.ReadLine();
            bool ifHitWall = false;
            while (command != "Christmas morning")
            {
                if (ChangePlayerPosition(santa, matrix, command) && ifHitWall ==false)
                {
                    ifHitWall = true; //if at least once hit a wall. Does, If Santa goes out of the neighborhood, means hit a wall ?
                }

                ChangeMatrix(santa, matrix);
                if (santa.Presents == 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            matrix[santa.X, santa.Y] = 'S'; // mark santa final position

            if (santa.Presents == 0 || ifHitWall)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            Print(matrix);

            Console.WriteLine(santa.NiceKidsCount == 0
                ? $"Good job, Santa! {initialKidCount} happy nice kid/s."
                : $"No presents for {santa.NiceKidsCount} nice kid/s.");
        }
        private static void FillMatrix(int matrixSize, char[,] matrix, Santa santa)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var matrixLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = char.Parse(matrixLine[j]);
                    FindInitialPlayerPNiceKidsCount(santa, matrix, j, i);
                }
            }
        }

        private static void ChangeMatrix(Santa santa, char[,] matrix)
        {
            if (matrix[santa.X, santa.Y] == 'V') // if is nice kid
            {
                GivePresentToNiceKid(santa);
                matrix[santa.X, santa.Y] = '-';
            }

            if (matrix[santa.X, santa.Y] == 'X') // if is naughty kid
            {
                matrix[santa.X, santa.Y] = '-';
            }

            if (matrix[santa.X, santa.Y] == 'C') // if it is a cookie
            {
                if (matrix[santa.X - 1, santa.Y] == 'V')
                {
                    GivePresentToNiceKid(santa);
                    matrix[santa.X - 1, santa.Y] = '-';
                }
                else if (matrix[santa.X - 1, santa.Y] == 'X')
                {
                    santa.Presents--;
                    matrix[santa.X - 1, santa.Y] = '-';
                }
                if (matrix[santa.X + 1, santa.Y] == 'V')
                {
                    GivePresentToNiceKid(santa);
                    matrix[santa.X + 1, santa.Y] = '-';
                }
                else if (matrix[santa.X + 1, santa.Y] == 'X')
                {
                    santa.Presents--;
                    matrix[santa.X + 1, santa.Y] = '-';

                }
                if (matrix[santa.X, santa.Y - 1] == 'V')
                {
                    GivePresentToNiceKid(santa);
                    matrix[santa.X, santa.Y - 1] = '-';
                }
                else if (matrix[santa.X, santa.Y - 1] == 'X')
                {
                    santa.Presents--;
                    matrix[santa.X, santa.Y - 1] = '-';
                }
                if (matrix[santa.X, santa.Y + 1] == 'V')
                {
                    GivePresentToNiceKid(santa);
                    matrix[santa.X, santa.Y + 1] = '-';
                }
                else if (matrix[santa.X, santa.Y + 1] == 'X')
                {
                    santa.Presents--;
                    matrix[santa.X, santa.Y + 1] = '-';
                }
                matrix[santa.X, santa.Y] = '-'; // remove the Cookie mark
            }
        }
        private static void GivePresentToNiceKid(Santa santa)
        {
            santa.Presents--;
            santa.NiceKidsCount--;
        }
        private static void FindInitialPlayerPNiceKidsCount(Santa santa, char[,] matrix, int j, int i)
        {
            if (matrix[i, j] == 'S')
            {
                matrix[i, j] = '-'; //need to remove initial santa mark
                santa.X = i;
                santa.Y = j;
            }

            if (matrix[i, j] == 'V')
            {
                santa.NiceKidsCount++;
            }
        }
        private static bool ChangePlayerPosition(Santa santa, char[,] matrix, string playerCommand) // if hit the wall stay there
        {
            if (playerCommand == "up")
            {
                if (santa.X - 1 < 0)
                {
                    santa.X = 0;
                    return true;
                }

                santa.X -= 1;
                return false;
            }
            if (playerCommand == "down")
            {
                if (santa.X + 1 >= matrix.GetLength(0))
                {
                    santa.X = matrix.GetLength(0) - 1;
                    return true;
                }
                santa.X += 1;
                return false;
            }
            if (playerCommand == "left")
            {
                if (santa.Y - 1 < 0)
                {
                    santa.Y = 0;
                    return true;
                }
                santa.Y -= 1;
                return false;
            }
            if (playerCommand == "right")
            {
                if (santa.Y + 1 >= matrix.GetLength(1))
                {
                    santa.Y = matrix.GetLength(1) - 1;
                    return true;
                }
                santa.Y += 1;
                return false;
            }
            return false;
        }
        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}