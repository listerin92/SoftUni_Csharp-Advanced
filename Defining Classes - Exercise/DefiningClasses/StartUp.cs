using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //person.Name = "Pesho";
            //person.Age = 20;

            //Person person2 = new Person("Gosho", 18);
            //Person person3 = new Person("Stamat", 43);
            //Person person4 = new Person(43);


            int noOfLines = int.Parse(Console.ReadLine());
            Family family = new Family();;
            for (int i = 0; i < noOfLines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                Person person = new Person();
                person.Name = name;
                person.Age = age;
                family.AddMember(person);
            }

            //Person oldestPerson = family.GetOldestMember();
            //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
            family.OlderThan30Sorted().ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));

        }
    }
}
