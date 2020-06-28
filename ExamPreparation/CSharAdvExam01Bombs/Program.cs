using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharAdvExam01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bombCasingLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> bombEffects = new Queue<int>(bombEffectsLine);
            Stack<int> bombCasing = new Stack<int>(bombCasingLine);
            int daturaBombs = 0,
                cherryBombs = 0,
                smokeDecoyBombs = 0;
            bool filledBombPouch = false;
            while (bombEffects.Any() && bombCasing.Any())
            {
                var currentBombEffect = bombEffects.Peek();
                var currentBombCasing = bombCasing.Peek();
                var sum = currentBombEffect + currentBombCasing;

                if (sum == 40)
                {
                    daturaBombs++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyBombs++;
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    var decreasedCurrentBombCasing = currentBombCasing - 5;
                    bombCasing.Pop();
                    bombCasing.Push(decreasedCurrentBombCasing);
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                {
                    filledBombPouch = true;
                    break;
                }
            }

            Console.WriteLine(filledBombPouch
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");
            if (!bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                var bombEffectsLeft = bombEffects.ToList();
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombEffectsLeft));
            }
            if (!bombCasing.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                var bombCasingLeft = bombCasing.ToList();
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasingLeft));
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
