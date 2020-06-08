using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            //60
            //1 20 b 20 20 a

            Stack<char> halls = new Stack<char>();
            Stack<int> reservations = new Stack<int>();
            int reservationCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
           // string[] reservation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
            Match result = re.Match(input);
            string alphaPart = result.Groups[1].Value;
            string numberPart = result.Groups[2].Value;
            char hall;
            int currentCapacity;
            //for (int i = 0; i < reservation.Length; i++)
            //{
            //    if (int.TryParse(reservation[i], out currentCapacity))
            //    {
            //        reservations.Push(currentCapacity);
            //    }
            //    else

            //    {
            //        hall = char.Parse(reservation[i]);
            //        halls.Push(hall);
            //    }
            //}

            bool overflow = false;
            StringBuilder sb = new StringBuilder();

            while (halls.Any() && reservations.Any())
            {
                char currentHall = halls.Peek();
                int currentHallCapacity = reservationCapacity;
                sb.Append($"{currentHall} -> ");

                while (currentHallCapacity > 0 && reservations.Any())
                {
                    int currentReservation = reservations.Peek();

                    if ((currentHallCapacity - currentReservation) > 0)
                    {
                        currentReservation = reservations.Pop();
                        currentHallCapacity -= currentReservation;
                        sb.Append($"{currentReservation}, "); 
                        overflow = false;
                    }

                    else if ((currentHallCapacity - currentReservation) < 0)

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
