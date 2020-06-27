using System;
using System.Linq;

namespace PresentDelivery_exerciseSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            var countOfPresents = int.Parse(Console.ReadLine());
            int neighborhoodSize = int.Parse(Console.ReadLine());
            char[,] hood = new char[neighborhoodSize, neighborhoodSize];
            int santaRow = -1;
            int santaCol = -1;
            int niceKidsCounter = 0;

            for (int i = 0; i < neighborhoodSize; i++)
            {
                var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < line.Length; j++)
                {
                    hood[i, j] = line[j];
                    if (hood[i, j] == 'S')
                    {
                        santaRow = i;
                        santaCol = j;
                    }

                    if (hood[i, j] == 'V')
                    {
                        niceKidsCounter++;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "Christmas morning")
            {
                hood[santaRow, santaCol] = '-';

                switch (command)
                {
                    case "up":
                        santaRow--;
                        break;
                    case "down":
                        santaRow++;
                        break;
                    case "left":
                        santaCol--;
                        break;
                    case "right":
                        santaCol++;
                        break;
                }

                if (hood[santaRow, santaCol] == 'V')
                {
                    countOfPresents--;
                }
                else if (hood[santaRow, santaCol] == 'C')
                {
                    if (hood[santaRow, santaCol - 1] != '-')
                    {
                        countOfPresents--;
                        hood[santaRow, santaCol - 1] = '-';
                    }
                    if (hood[santaRow, santaCol + 1] != '-')
                    {
                        countOfPresents--;
                        hood[santaRow, santaCol + 1] = '-';
                    }
                    if (hood[santaRow - 1, santaCol] != '-')
                    {
                        countOfPresents--;
                        hood[santaRow - 1, santaCol] = '-';
                    }
                    if (hood[santaRow + 1, santaCol] != '-')
                    {
                        countOfPresents--;
                        hood[santaRow + 1, santaCol] = '-';
                    }
                }
                if (countOfPresents <= 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }

                command = Console.ReadLine();
            }
            hood[santaRow, santaCol] = 'S';

            int niceKidsWithNoPresents = 0;
            for (int i = 0; i < hood.GetLength(0); i++)
            {
                for (int j = 0; j < hood.GetLength(1); j++)
                {
                    Console.Write(hood[i, j] + " ");
                    if (hood[i, j] == 'V')
                    {
                        niceKidsWithNoPresents++;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(niceKidsWithNoPresents == 0
                ? $"Good job, Santa! {niceKidsCounter} happy nice kid/s."
                : $"No presents for {niceKidsWithNoPresents} nice kid/s.");
        }
    }
}