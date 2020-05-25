using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class SoftUni_Party
    {
        static void Main(string[] args)
        {

            var regularGuests = new HashSet<string>();
            var vipGuests = new HashSet<string>();
            bool letsParty = false;

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                if (line == "PARTY")
                {
                    letsParty = true;
                    continue;
                }

                if (letsParty)
                {
                    if (Char.IsDigit(line[0]))
                    {
                        vipGuests.Remove(line);

                    }
                    else
                    {
                        regularGuests.Remove(line);
                    }
                }
                else
                {
                    if (Char.IsDigit(line[0]))
                    {
                        vipGuests.Add(line);
                    }
                    else
                    {
                        regularGuests.Add(line);
                    }
                }
            }

            Print(regularGuests, vipGuests);
        }

        private static void Print(HashSet<string> regularGuests, HashSet<string> vipGuests)
        {
            Console.WriteLine(regularGuests.Count + vipGuests.Count);
            foreach (var item in vipGuests)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regularGuests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
