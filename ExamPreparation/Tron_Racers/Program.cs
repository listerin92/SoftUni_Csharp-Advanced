using System;
using System.Linq;

namespace Tron_Racers

{
    public class Player
    {

        public int X { get; set; }
        public int Y { get; set; }
        public char Flag { get; set; }

        public char CheckPosition(char[,] matrix)
        {
            return matrix[this.X, this.Y];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            Player playerOne = new Player();
            Player playerTwo = new Player();
            FillMatrix(matrixSize, matrix, playerOne, playerTwo);

            while (true)
            {
                string[] commandLine = Console.ReadLine().Split(' ').ToArray();
                string firstPlayerCommand = commandLine[0];
                string secondPlayerCommand = commandLine[1];

                if (PlayerMove(playerOne, firstPlayerCommand, matrix) || PlayerMove(playerTwo, secondPlayerCommand, matrix))
                {
                    break;
                }
            }
            
            Print(matrix);
        }

        private static void FillMatrix(int matrixSize, char[,] matrix, Player playerOne, Player playerTwo)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                string matrixLine = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrixLine[j];
                    FindInitialPlayersPosition(playerOne, playerTwo, matrixLine, j, i);
                }
            }
        }

        private static void FindInitialPlayersPosition(Player playerOne, Player playerTwo, string matrixLine, int j, int i)
        {
            if (matrixLine[j] == 'f')
            {
                playerOne.X = i;
                playerOne.Y = j;
                playerOne.Flag = 'f';
            }

            if (matrixLine[j] == 's')
            {
                playerTwo.X = i;
                playerTwo.Y = j;
                playerTwo.Flag = 's';
            }
        }

        private static bool PlayerMove(Player player, string playerCommand, char[,] matrix)
        {

            ChangePlayerPosition(player, matrix, playerCommand);
            return ChangeMatrix(player, matrix);
        }

        private static bool ChangeMatrix(Player player, char[,] matrix)
        {
            if (IsOtherPlayerOccupied(player, matrix))
            {
                matrix[player.X, player.Y] = 'x';
                return true; // mark as dead
            }

            matrix[player.X, player.Y] = player.Flag; //move to next safe position and mark it
            return false;
        }

        private static bool IsOtherPlayerOccupied(Player player, char[,] matrix)
        {
            return matrix[player.X, player.Y] != player.Flag && matrix[player.X, player.Y] != '*'; //if not my flag and not empty
        }

        private static void ChangePlayerPosition(Player player, char[,] matrix, string playerCommand)
        {
            if (playerCommand == "up")
            {
                if (player.X - 1 < 0)
                {
                    player.X = matrix.GetLength(0) - 1;
                }
                else
                {
                    player.X = player.X - 1;
                }
            }
            else if (playerCommand == "down")
            {
                if (player.X + 1 >= matrix.GetLength(0))
                {
                    player.X = 0;
                }
                else
                {
                    player.X = player.X + 1;
                }
            }
            else if (playerCommand == "left")
            {
                if (player.Y - 1 < 0)
                {
                    player.Y = matrix.GetLength(1) - 1;
                }
                else
                {
                    player.Y = player.Y - 1;
                }
            }
            else if (playerCommand == "right")
            {
                if (player.Y + 1 >= matrix.GetLength(1))
                {
                    player.Y = 0;
                }
                else
                {
                    player.Y = player.Y + 1;
                }
            }
        }
        private static void Print(char[,] matrix)
        {
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
