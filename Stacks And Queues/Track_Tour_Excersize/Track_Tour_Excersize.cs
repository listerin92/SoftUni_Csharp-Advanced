using System;
using System.Collections.Generic;
using System.Linq;

namespace Track_Tour_Excersize
{
    class Track_Tour_Excersize
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }
            int index = 0, counter = 0;
            int length = pumps.Count;

            for (int i = 0; i < length; i++)
            {
                int totalAmmount = 0;
                bool isCompleted = true;

                for (int j = 0; j < length; j++)
                {
                    string currentPump = pumps.Dequeue();
                    int[] currentPumpsValues = currentPump.Split().Select(int.Parse).ToArray();
                    int currentAmmount = currentPumpsValues[0];
                    int distance = currentPumpsValues[1];
                    totalAmmount += currentAmmount;

                    if (totalAmmount >= distance)
                    {
                        totalAmmount -= distance;
                    }
                    else
                    {
                        isCompleted = false;
                    }

                    pumps.Enqueue(currentPump);
                }

                if (isCompleted)
                {
                    index = i;
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
