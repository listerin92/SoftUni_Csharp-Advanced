using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Jagged_Array_Modification
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int[][] jagged = new int[input][];
            int sum = 0;
            for (int row = 0; row < jagged.Length; row++)
            {
                int[] collumn = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jagged[row] = new int[input];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = collumn[col];

                }
            }

            string[] cmd = Console.ReadLine().Split(" ").ToArray();


            while (cmd[0] != "END")
            {
                int rowToChange = int.Parse(cmd[1]);
                int colToChange = int.Parse(cmd[2]);
                int valToChange = int.Parse(cmd[3]);
                switch (cmd[0])
                {
                    case "Add":
                        {
                            if (rowToChange < jagged[0].Length 
                                && colToChange < jagged[0].Length
                                && rowToChange >= 0
                                & colToChange >= 0)
                            {
                                jagged[rowToChange][colToChange] += valToChange;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid coordinates");
                            }
                            break;
                        }
                    case "Subtract":
                        {
                            if (rowToChange < jagged[0].Length
                                && colToChange < jagged[0].Length
                                && rowToChange >= 0
                                & colToChange >= 0)
                            {
                                jagged[rowToChange][colToChange] -= valToChange;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid coordinates");
                            }
                            break;
                        }
                }
                cmd = Console.ReadLine().Split(" ").ToArray();
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
