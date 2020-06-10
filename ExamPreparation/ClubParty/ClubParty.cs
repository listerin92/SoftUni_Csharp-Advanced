namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class ClubParty
    {
        static void Main(string[] args)
        {
            //60
            //1 20 b 20 20 a


            var maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] reservation = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<char> halls = new Stack<char>();
            Stack<int> reservations = new Stack<int>();
            char hall;
            int currentCapacity;
            for (int i = 0; i < reservation.Length; i++)
            {
                if (int.TryParse(reservation[i], out currentCapacity))
                {
                    reservations.Push(currentCapacity);
                }
                else

                {
                    hall = char.Parse(reservation[i]);
                    halls.Push(hall);
                }
            }
            // not understand task - you should read from one stack, linear !!!, otherwise you could not known the sequence !!!
            // 75/100 in Judge - In fact the task is quite simple, check other Solution - code is from Exam Preparation 

            StringBuilder sb = new StringBuilder();

            while (halls.Any() && reservations.Any())

            {
                bool overflow = false;
                char currentHall = halls.Peek();
                int currentHallCapacity = maxCapacity;
                sb.Append($"{currentHall} -> ");

                while (reservations.Any())
                {
                    var currentReservation = reservations.Peek();
                    var testCapacity = currentHallCapacity - currentReservation;
                    if (testCapacity >= 0)
                    {
                        currentReservation = reservations.Pop();
                        currentHallCapacity -= currentReservation;
                        sb.Append($"{currentReservation}, ");
                    }

                    if (testCapacity <= 0)
                    {
                        overflow = true;
                        halls.Pop();
                        break;
                    }
                }

                if (!overflow) continue;
                Console.WriteLine(sb.ToString().TrimEnd(new[] { ',', ' ' }));
                sb.Clear();
            }
        }
    }
}
