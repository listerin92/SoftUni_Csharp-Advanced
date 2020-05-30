using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            DateModifier check = new DateModifier();
            Console.WriteLine(check.CalculateDifference(dateOne, dateTwo));
        }
    }
}
