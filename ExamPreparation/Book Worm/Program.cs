using System;

namespace Book_Worm
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char CheckPosition(char[,] matrix)
        {
            return matrix[this.X, this.Y];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            Player player = new Player();
            FillMatrix(matrixSize, matrix, player);
            string command = Console.ReadLine();

            while (command != "end")
            {
                bool hit = ChangePlayerPosition(player, matrix, command);
                ChangeMatrix(player, matrix, ref initialString, hit);
                command = Console.ReadLine();
            }

            matrix[player.X, player.Y] = 'P';
            Print(matrix, initialString);
        }
        private static void FillMatrix(int matrixSize, char[,] matrix, Player playerOne)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                string matrixLine = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrixLine[j];
                    FindInitialPlayerPosition(playerOne, matrix, j, i);
                }
            }
        }
        private static void ChangeMatrix(Player player, char[,] matrix, ref string initialString, bool hit)
        {
            if (initialString.Length > 1 && hit)
            {
                initialString = initialString.Remove(initialString.Length - 1);
            }
            if (IsLetter(player, matrix))
            {
                initialString = initialString + matrix[player.X, player.Y];
                matrix[player.X, player.Y] = '-';
            }
        }

        private static bool IsLetter(Player player, char[,] matrix)
        {
            return matrix[player.X, player.Y] != '-';
        }

        private static void FindInitialPlayerPosition(Player playerOne, char[,] matrix, int j, int i)
        {
            if (matrix[i, j] == 'P')
            {
                matrix[i, j] = '-'; //need to remove initial player mark
                playerOne.X = i;
                playerOne.Y = j;
            }
        }
        private static bool ChangePlayerPosition(Player player, char[,] matrix, string playerCommand) // if hit the wall stay there
        {
            if (playerCommand == "up")
            {
                if (player.X - 1 < 0)
                {
                    player.X = 0;
                    return true;
                }

                player.X = player.X - 1;
                return false;
            }
            if (playerCommand == "down")
            {
                if (player.X + 1 >= matrix.GetLength(0))
                {
                    player.X = matrix.GetLength(0) - 1;
                    return true;
                }
                player.X = player.X + 1;
                return false;
            }
            if (playerCommand == "left")
            {
                if (player.Y - 1 < 0)
                {
                    player.Y = 0;
                    return true;
                }
                player.Y = player.Y - 1;
                return false;
            }
            if (playerCommand == "right")
            {
                if (player.Y + 1 >= matrix.GetLength(1))
                {
                    player.Y = matrix.GetLength(1) - 1;
                    return true;
                }
                player.Y = player.Y + 1;
                return false;
            }
            return false;
        }
        private static void Print(char[,] matrix, string initialString)
        {
            Console.WriteLine(initialString);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
