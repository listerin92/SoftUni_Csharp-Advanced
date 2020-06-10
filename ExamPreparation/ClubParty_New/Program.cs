using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty_New
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] reservation = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> elements = new Stack<string>(reservation);
            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();
            int currentCapacity = 0;

            while (elements.Count > 0)
            {
                string currentElement = elements.Pop();
                bool isNumber = int.TryParse(currentElement, out int parsedNumber);
                if (!isNumber)
                {
                    // if it is not digit it is a hall - take the hall
                    halls.Enqueue(currentElement); 
                }
                else
                {
                    // if no halls, skip, works when a hall is not taken or hall is overfill and removed
                    if (halls.Count == 0) 
                    {
                        continue;
                    }
                    // print if overfill, and remove hall from the queue and clear list of people for it.
                    if (currentCapacity + parsedNumber > maxCapacity) 
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }
                    
                    // add persons to the hall only if hall exist, this skips adding persons if you don't have a free hall !
                    if (halls.Count > 0) 
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }
                }
            }
        }
    }
}
/*
 *  Club Party
A new club has opened in town and everyone wants to go partying. The club has many halls and people may only go there with reservations.
You will be given n – an integer specifying the halls' maximum capacity. 
Then you will be given input line which will contain English alphabet letters and numbers, separated by a single space. 
The input for the line should be read from the last inserted to the first one. 
The letters represent the halls and the numbers – the people in a single reservation. 
Companies of people should go in the halls. The first entered hall is the first which people are entering. 
Every reservation takes specific capacity, equal to its number.
When a hall overflows (it cannot contain a given number of people due to lack of enough free capacity), it passes the people to the next entered hall. 
If there is no open hall and you receive a reservation, you should skip it.
If a hall overflows you must remove it, and print it on the console, along with all of the companies of people it currently contains. 
After you’ve removed that hall, the next one becomes the first in the order – people will first be passed to it. 
Input
•	The first line will be halls' maximum capacity.
•	The second line will contain letters and digits separated by a space.
Output
•	For output, you must print a hall, every time it overflows, after removing it.
•	The format is the following: {hall} -> {reservation1}, {reservation2}…
•	Where {hall} is the letter that corresponds to that hall, and the reservations are the numbers. 
Constraints
•	The halls will only be English alphabet letters.
•	Each hall’s letter will always be unique.
•	The integer n will be in the range [0, 500].
•	The reservations will always be valid integers in the range [0, 500].

Input                                   Output
60
1 20 b 20 20 a                          a -> 20, 20, 20

Comment
“a” is the first entered hall. Then we receive the reservations 20 and 20 which are passed to “a”. 
Then we get the hall “b”. Then again, we receive a reservation 20. “a” still has enough capacity to hold the people so they enter there.
Then we get the reservation 1. “a” has capacity 60/60 – it overflows, so we pass the person to the next hall. 
We find “b” and we pass the person to “b”. “a” is then removed and printed on the console. “b” becomes the first hall now.


Input	                                Output
50
15 a 40 30 20 c 15 10 b	                b -> 10, 15, 20
                                        c -> 30

Input	                                Output
40
20 20 20 20 20 20 D F 15 5 M 26 38	    M -> 5, 15, 20 
                                        F -> 20, 20
                                        D -> 20, 20
 */
