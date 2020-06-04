using System;
using System.Linq;

namespace _08._Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').ToArray();
            var FirstPlusLast = new string(firstLine[0] + " " + firstLine[1]);
            var address = firstLine[2];
            var town1 = firstLine[3];
            var town = town1;
            if (firstLine.Length-1 > 3)
            {
                var town2 = firstLine[4];
                town = town1 + " " + town2;
            }

            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(FirstPlusLast, address, town);

            var secondLine = Console.ReadLine().Split(' ').ToArray();
            var name = secondLine[0];
            var litersOfBeer = int.Parse(secondLine[1]);
            var drunkOrNot = secondLine[2] == "drunk" ? "True" : "False";
            
            Threeuple<string, int, string> secondThreeuple = new Threeuple<string, int, string>(name, litersOfBeer, drunkOrNot);

            var thirdLine = Console.ReadLine().Split(' ').ToArray();
            var name2 = thirdLine[0];
            var accountBalance = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name2, accountBalance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);

        }
    }
}
