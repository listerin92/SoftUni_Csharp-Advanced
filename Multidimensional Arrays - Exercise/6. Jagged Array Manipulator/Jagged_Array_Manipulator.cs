using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Jagged_Array_Manipulator
    {
        static void Main()
        {
            byte noOfRows = byte.Parse(Console.ReadLine());
            decimal[][] jagged = new decimal[noOfRows][];

            for (int i = 0; i < noOfRows; i++)
            {
                long[] rows = Console.ReadLine()
                    .Split(' ',
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                jagged[i] = new decimal[rows.Length];
                for (int j = 0; j < rows.Length; j++)
                {
                    jagged[i][j] = rows[j];
                }
            }

            MultiplyDivide(jagged);



            while (true)
            {
                string c = Console.ReadLine();

                if (c.ToLower() == "end")
                {
                    break;
                }

                string[] cmd = c.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmd.Length != 4)
                {
                    continue;
                }

                string command = cmd[0];
                int row = int.Parse(cmd[1]);
                int column = int.Parse(cmd[2]);
                long value = int.Parse(cmd[3]);


                switch (command)
                {
                    case "Add":
                        {
                            if (CheckRowCol(jagged, row, column))
                            {
                                jagged[row][column] += value;
                            }
                            break;
                        }
                    case "Subtract":
                        {
                            if (CheckRowCol(jagged, row, column))
                            {
                                jagged[row][column] -= value;
                            }
                            break;
                        }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static void MultiplyDivide(decimal[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    jagged[i] = jagged[i].Select(x => x * 2m).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();

                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2m).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2m).ToArray();
                }
            }
        }

        private static bool CheckRowCol(decimal[][] jagged, int row, int column)
        {
            if (row >= 0 && row <= jagged.Length)
            {
                if (column >= 0 && column <= jagged[row].Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
