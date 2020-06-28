using System;

namespace CSharpAdvExam02Snake
{
    public class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BurrowOneX { get; set; }
        public int BurrowOneY { get; set; }
        public int BurrowTwoX { get; set; }
        public int BurrowTwoY { get; set; }
        public bool FirstBurrowFound { get; set; }
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
            Snake snake = new Snake();
            FillMatrix(matrixSize, matrix, snake);
            string command = Console.ReadLine();
            int foodQuantity = 0;
            bool hitAWall = false;
            while (true)
            {
                hitAWall = ChangePlayerPosition(snake, matrix, command);
                if (hitAWall || foodQuantity >= 10)
                {
                    break;
                }

                if (matrix[snake.X, snake.Y] == '*')
                {
                    foodQuantity++;
                }

                if (matrix[snake.X, snake.Y] == 'B')
                {
                    if ((snake.X == snake.BurrowOneX) && (snake.Y == snake.BurrowOneY))
                    {
                        matrix[snake.X, snake.Y] = '.';
                        snake.X = snake.BurrowTwoX;
                        snake.Y = snake.BurrowTwoY;
                    }
                    else
                    {
                        snake.X = snake.BurrowOneX;
                        snake.Y = snake.BurrowOneY;
                    }
                }
                if (foodQuantity >= 10)
                {
                    matrix[snake.X, snake.Y] = 'S';
                    break;
                }
                matrix[snake.X, snake.Y] = '.';
                command = Console.ReadLine();
            }

            if (hitAWall && foodQuantity <= 10) //!!!
            {
                Console.WriteLine($"Game over!");
            }
            if (foodQuantity >= 10)
            {
                Console.WriteLine($"You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            Print(matrix);
        }
        private static void FillMatrix(int matrixSize, char[,] matrix, Snake snake)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                string matrixLine = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrixLine[j];
                    FindInitialPlayerPosition(snake, matrix, j, i);
                }
            }
        }
        private static void FindInitialPlayerPosition(Snake snake, char[,] matrix, int j, int i)
        {
            if (matrix[i, j] == 'S')
            {
                matrix[i, j] = '.'; //need to remove initial player mark
                snake.X = i;
                snake.Y = j;
            }

            if (matrix[i, j] == 'B' && !snake.FirstBurrowFound)
            {
                snake.BurrowOneX = i;
                snake.BurrowOneY = j;
                snake.FirstBurrowFound = true;
            }
            else if (matrix[i, j] == 'B' && snake.FirstBurrowFound)
            {
                snake.BurrowTwoX = i;
                snake.BurrowTwoY = j;
            }
        }
        private static void ChangeMatrix(Snake snake, char[,] matrix, bool hit)
        {
            // TODO
        }
        private static bool ChangePlayerPosition(Snake snake, char[,] matrix, string playerCommand) // if hit the wall return true
        {
            if (playerCommand == "up")
            {
                if (snake.X - 1 < 0)
                {
                    snake.X = 0;
                    return true;
                }

                snake.X -= 1;
                return false;
            }
            if (playerCommand == "down")
            {
                if (snake.X + 1 >= matrix.GetLength(0))
                {
                    snake.X = matrix.GetLength(0) - 1;
                    return true;
                }
                snake.X += 1;
                return false;
            }
            if (playerCommand == "left")
            {
                if (snake.Y - 1 < 0)
                {
                    snake.Y = 0;
                    return true;
                }
                snake.Y -= 1;
                return false;
            }
            if (playerCommand == "right")
            {
                if (snake.Y + 1 >= matrix.GetLength(1))
                {
                    snake.Y = matrix.GetLength(1) - 1;
                    return true;
                }
                snake.Y += 1;
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
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
