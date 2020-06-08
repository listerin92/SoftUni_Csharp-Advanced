using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            SortedSet<Person> personsSortedSet = new SortedSet<Person>();
            HashSet<Person> personsHashSet = new HashSet<Person>();
            for (int i = 0; i < input; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);
                personsSortedSet.Add(person);
                personsHashSet.Add(person);
            }

            Console.WriteLine(personsSortedSet.Count);
            Console.WriteLine(personsHashSet.Count);
        }
    }
}
