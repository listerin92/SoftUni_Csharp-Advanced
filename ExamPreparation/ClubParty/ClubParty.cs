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


            var reservationCapacity = int.Parse(Console.ReadLine());
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

            StringBuilder sb = new StringBuilder();

            while (halls.Any() && reservations.Any())

            {
                bool overflow = false;
                char currentHall = halls.Peek();
                int currentHallCapacity = reservationCapacity;
                sb.Append($"{currentHall} -> ");

                while (reservations.Any())
                {
                    int currentReservation = reservations.Peek();
                    int testCapacity = currentHallCapacity - currentReservation;
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

                if (overflow)
                {
                    Console.WriteLine(sb.ToString().TrimEnd(new[] { ',', ' ' }));
                    sb.Clear();
                }
            }
        }
    }
}
