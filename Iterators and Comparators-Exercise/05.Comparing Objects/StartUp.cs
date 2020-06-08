using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();
            while (input != "END")
            {
                string[] tokens = input.Split(' ').ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person(name, age, town);
                persons.Add(person);
                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine());
            int matchedPeople = 0, notMatchedPeople = 0;
            var targetPerson = persons[personIndex - 1];
            
            foreach (var person in persons)
            {
                
                if (person.CompareTo(targetPerson) == 0)
                {
                    matchedPeople++;
                }
                else 
                {
                    notMatchedPeople++;
                }
            }

            Console.WriteLine(matchedPeople == 1
                ? "No matches"
                : $"{matchedPeople} {notMatchedPeople} {persons.Count}");
        }
    }
}