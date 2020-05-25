using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class The_V_Logger
    {
        static void Main(string[] args)
        {
            // vlogger => followers 


            Dictionary<string, Dictionary<string, HashSet<string>>> vlogers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens = input.Split().ToArray();
                string nameOfVlogger = string.Empty;
                string nameOfFollower = string.Empty;
                string command = tokens[1];

                if (tokens.Length == 4)// joined The V-Loogger command
                {
                    nameOfVlogger = tokens[0];
                    if (!vlogers.ContainsKey(nameOfFollower))
                    {
                        vlogers[nameOfVlogger] = new Dictionary<string, HashSet<string>>();
                        vlogers[nameOfVlogger].Add("followers", new HashSet<string>());
                        vlogers[nameOfVlogger].Add("following", new HashSet<string>());
                    }
                }
                else // followed command
                {
                    nameOfFollower = tokens[0];
                    nameOfVlogger = tokens[2];
                    if (vlogers.ContainsKey(nameOfVlogger)
                        && vlogers.ContainsKey(nameOfFollower) && nameOfVlogger != nameOfFollower)
                    {
                        vlogers[nameOfVlogger]["followers"].Add(nameOfFollower);
                        vlogers[nameOfFollower]["following"].Add(nameOfVlogger);
                    }
                }
            }

            Print(vlogers);
        }

        private static void Print(Dictionary<string, Dictionary<string, HashSet<string>>> vlogers)
        {
            int number = 1;
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            foreach (var vlogger in vlogers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }
        }
    }
}
