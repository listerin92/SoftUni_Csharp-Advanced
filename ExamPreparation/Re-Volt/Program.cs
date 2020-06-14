using System;

namespace Re_Volt
{
    public class Player
    {
        private char _finishFlag = 'F';
        public int X { get; set; }
        public int Y { get; set; }

        public char FinishFlag
        {
            get => _finishFlag;
            set => _finishFlag = value;
        }

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
            int numberOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            Player player = new Player();
            FillMatrix(matrixSize, matrix, player);

            while (true)
            {
                if (numberOfCommands == 0)
                {
                    matrix[player.X, player.Y] = 'f';
                    break;
                }
                string command = Console.ReadLine();

                ChangePlayerPosition(player, matrix, command);
                ChangeMatrix(player, matrix, command);
                numberOfCommands--;
            }
            Console.WriteLine(player.FinishFlag == 'f' ? "Player won!" : "Player lost!");
            Print(matrix);
        }

        private static void ChangeMatrix(Player player, char[,] matrix, string playerCommand)
        {
            if (IsOccupiedByBonus(player, matrix))
            {
                ChangePlayerPosition(player, matrix, playerCommand); //if Bonus pass once again the position
            }

            if (IsOccupiedByTrap(player, matrix))
            {
                string reverseCommand = ReverseCommand(playerCommand);
                ChangePlayerPosition(player, matrix, reverseCommand); // if trap go back with reverse command;
            }

            if (IsWon(player, matrix)) // if Won change Finish F to my f, and change finish flag
            {
                matrix[player.X, player.Y] = 'f';
                player.FinishFlag = 'f';
            }
        }

        private static string ReverseCommand(string playerCommand)
        {
            if (playerCommand == "up")
            {
                return "down";
            }

            if (playerCommand == "down")
            {
                return "up";
            }
            if (playerCommand == "left")
            {
                return "right";
            }
            return "left";
        }

        private static bool IsOccupiedByBonus(Player player, char[,] matrix) => matrix[player.X, player.Y] == 'B';
        private static bool IsOccupiedByTrap(Player player, char[,] matrix) => matrix[player.X, player.Y] == 'T';
        private static bool IsWon(Player player, char[,] matrix) => matrix[player.X, player.Y] == 'F';

        private static void FillMatrix(int matrixSize, char[,] matrix, Player playerOne)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                string matrixLine = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrixLine[j];
                    FindInitialPlayerPositionAndFinish(playerOne, matrix, j, i);
                }
            }
        }
        private static void FindInitialPlayerPositionAndFinish(Player playerOne, char[,] matrix, int j, int i)
        {
            if (matrix[i, j] == 'f')
            {
                matrix[i, j] = '-'; //need to remove initial player mark
                playerOne.X = i;
                playerOne.Y = j;
            }
        }

        private static void ChangePlayerPosition(Player player, char[,] matrix, string playerCommand) //if hit the wall go the oposite side
        {
            if (playerCommand == "up")
            {
                player.X = player.X - 1 < 0 ? matrix.GetLength(0) - 1 : player.X - 1;
            }
            else if (playerCommand == "down")
            {
                player.X = player.X + 1 >= matrix.GetLength(0) ? 0 : player.X + 1;
            }
            else if (playerCommand == "left")
            {
                player.Y = player.Y - 1 < 0 ? matrix.GetLength(1) - 1 : player.Y - 1;
            }
            else if (playerCommand == "right")
            {
                player.Y = player.Y + 1 >= matrix.GetLength(1) ? 0 : player.Y + 1;
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