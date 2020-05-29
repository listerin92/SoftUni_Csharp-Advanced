using System;
using System.Linq;

namespace _12._TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Func<string, char[]> funcToCharArr = x => x.ToCharArray();
            Func<char, int> castFunc = y => (int)y;
            Func<string, bool> finalFunc = x => funcToCharArr(x)
                .Select(castFunc).Sum() >= number;

            Console.WriteLine(Console.ReadLine()
                .Split()
                .FirstOrDefault(finalFunc));

            //Console.WriteLine(new Func<int, string>(a => Console.ReadLine()
            //   .Split()
            //   .FirstOrDefault(x => x.ToCharArray()
            //       .Sum(y => (int)y) >= a))
            //    .Invoke(int.Parse(Console.ReadLine())));
        }
    }
}
