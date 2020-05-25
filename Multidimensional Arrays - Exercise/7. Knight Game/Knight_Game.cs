using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Knight_Game
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int rowscols = input;
            char[,] chessBoard = new char[rowscols, rowscols];
            for (int i = 0; i < rowscols; i++)
            {
                char[] column = Console.ReadLine().ToCharArray();
                for (int j = 0; j < rowscols; j++)
                {
                    chessBoard[i, j] = column[j];
                }
            }

            int maxAttacked = 0, maxRow = 0, maxColumn = 0, countOfRemovedKnights = 0;
            do
            {
                if (maxAttacked > 0)
                {
                    chessBoard[maxRow, maxColumn] = '0';
                    maxAttacked = 0;
                    countOfRemovedKnights++;
                }

                for (int i = 0; i < chessBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < chessBoard.GetLength(1); j++)
                    {
                        if (chessBoard[i, j] == 'K')
                        {
                            var currentAttack = CalculateAttacks(i, j, chessBoard);

                            if (currentAttack > maxAttacked)
                            {
                                maxAttacked = currentAttack;
                                maxRow = i;
                                maxColumn = j;
                            }
                        }

                    }
                }
            } while (maxAttacked > 0);

            Console.WriteLine(countOfRemovedKnights);

        }

        private static int CalculateAttacks(int row, int column, char[,] board)
        {
            int result = 0;

            if (IsPositionAttacked(row - 2, column - 1, board)) result++;
            if (IsPositionAttacked(row - 2, column + 1, board)) result++;
            if (IsPositionAttacked(row - 1, column - 2, board)) result++;
            if (IsPositionAttacked(row - 1, column + 2, board)) result++;
            if (IsPositionAttacked(row + 1, column - 2, board)) result++;
            if (IsPositionAttacked(row + 1, column + 2, board)) result++;
            if (IsPositionAttacked(row + 2, column - 1, board)) result++;
            if (IsPositionAttacked(row + 2, column + 1, board)) result++;

            return result;
        }
        private static bool IsPositionAttacked(int row, int column, char[,] board)
        {
            return IsOnChessBoard(row, column, board.GetLength(0))
                   && board[row, column] == 'K';
        }

        private static bool IsOnChessBoard(int row, int column, int n)
        {
            return (row >= 0 && row < n && column >= 0 && column < n);
        }
    }
}