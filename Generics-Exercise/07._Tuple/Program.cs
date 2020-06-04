using System;
using System.Linq;

namespace _07._Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').ToArray();
            var FirstPlusLast = new string(firstLine[0] + " " + firstLine[1]);
            var address = firstLine[2];
            Tuple<string, string> firstTupple = new Tuple<string, string>(FirstPlusLast, address);

            var secondLine = Console.ReadLine().Split(' ').ToArray();
            var name = secondLine[0];
            var littersOfBeer = int.Parse(secondLine[1]);
            Tuple<string, int> secondTupple = new Tuple<string, int>(name, littersOfBeer);

            
            var thirdLine = Console.ReadLine().Split(' ').ToArray();
            var integerLine = int.Parse(thirdLine[0]);
            var doubleLine = double.Parse(thirdLine[1]);
            Tuple<int, double> thirdTupple = new Tuple<int, double>(integerLine, doubleLine);

            Console.WriteLine(firstTupple);
            Console.WriteLine(secondTupple);
            Console.WriteLine(thirdTupple);


        }
    }
}
