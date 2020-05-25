using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {

            //              Правя един клас Contest {
            //              name: String
            //              password: String
            //              maxScore : int
            //              void updateMaxScoreIfNeeded(x: int) { }
            //              }
            //              после един клас ContestS
            //              и накрая едно dictionary<username, ContestS>

            // CandidateName => Course => Score
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            // Course => Pass
            Dictionary<string, string> coursePass = new Dictionary<string, string>();

            InputCoursePass(coursePass);
            InputCourseLoginCandidateScores(candidates, coursePass);

            int maxSum;
            string bestCandidate;

            FindBestCandidate(candidates, out maxSum, out bestCandidate);

            Print(candidates, maxSum, bestCandidate);

        }

        private static void Print(Dictionary<string, Dictionary<string, int>> candidates, int maxSum, string bestCandidate)
        {
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxSum} points.");
            Console.WriteLine("Ranking");
            foreach (var candidate in candidates.OrderBy(o => o.Key))
            {
                string name = candidate.Key;
                Console.WriteLine($"{name}");
                var courseScore = candidate.Value;
                foreach (var item in courseScore.OrderByDescending(v => v.Value))
                {
                    string course = item.Key;
                    int score = item.Value;
                    Console.WriteLine($"# {course}->{score}");
                }
            }
        }

        private static void FindBestCandidate(Dictionary<string, Dictionary<string, int>> candidates, out int maxSum, out string bestCandidate)
        {
            int sum = 0;
            maxSum = -1;
            bestCandidate = string.Empty;
            foreach (var candidate in candidates)
            {
                var courseScore = candidate.Value;
                foreach (var item in courseScore)
                {
                    int score = item.Value;
                    sum += score;
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestCandidate = candidate.Key;
                    }
                }
                sum = 0;
            }
        }

        private static void InputCourseLoginCandidateScores(Dictionary<string, Dictionary<string, int>> candidates, Dictionary<string, string> coursePass)
        {
            while (true)
            {
                string courseContestPassLine = Console.ReadLine();
                if (courseContestPassLine == "end of submissions")
                {
                    break;
                }
                string[] tokens = courseContestPassLine.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = tokens[0];
                string pass = tokens[1];
                string name = tokens[2];
                int score = int.Parse(tokens[3]);

                if (coursePass.ContainsKey(courseName) && coursePass[courseName] == pass) //new that course exist and pass is correct
                {
                    if (!candidates.ContainsKey(name))
                    {
                        candidates[name] = new Dictionary<string, int>();
                    }
                    if (!candidates[name].ContainsKey(courseName))
                    {
                        candidates[name][courseName] = 0;
                    }

                    if (candidates[name][courseName] < score) // submit only bestScore
                    {
                        candidates[name][courseName] = score;
                    }
                }

            }
        }

        private static void InputCoursePass(Dictionary<string, string> coursePass)
        {
            while (true)
            {
                string coursePassLine = Console.ReadLine();
                if (coursePassLine == "end of contests")
                {
                    break;
                }
                string[] tokens = coursePassLine.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = tokens[0];
                string pass = tokens[1];
                if (!coursePass.ContainsKey(courseName))
                {
                    coursePass[courseName] = "";
                }
                coursePass[courseName] = pass;
            }
        }
    }
}
