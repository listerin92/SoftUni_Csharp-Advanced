using System;
using System.Linq;

namespace _10._Predicate_Party
{
    class Predicate_Party
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split()
                .ToList();
            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string filterCommand = tokens[1];
                string criteria = tokens[2];
                Func<string, string, bool> predicate = GetFunc(filterCommand);

                if (command == "Remove")
                {
                    guests = guests.Where(x => !predicate(x, criteria)).ToList();
                }
                else if (command == "Double")
                {
                    var guestToAdd = guests.Where(x => predicate(x, criteria)).ToList();

                    foreach (var name in guestToAdd)
                    {
                        int index = guests.IndexOf(name);
                        guests.Insert(index + 1, name);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }
        static Func<string, string, bool> GetFunc(string filterCommand)
        {
            if (filterCommand == "StartsWith")
            {
                return (x, c) => x.StartsWith(c);
            }

            else if (filterCommand == "EndsWith")
            {
                return (x, c) => x.EndsWith(c);
            }

            else if (filterCommand == "Length")
            {
                return (x, c) => x.Length == int.Parse(c);
            }
            return null;
        }
    }
}