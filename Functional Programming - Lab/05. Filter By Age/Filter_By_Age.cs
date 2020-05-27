using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{

    //Write a program that receives an integer N on first line.On the next N lines, read pairs of "[name], [age]". Then read three lines with:
    //•	Condition - "younger" or "older"
    //•	Age - Integer
    //•	Format - "name", "age" or "name age"
    //Depending on the condition, print the correct pairs in the correct format.
    //Don’t use the built-in functionality from.NET.Create your own methods.
    //Input
    //
    //5
    //Lucas, 20
    //Tomas, 18
    //Mia, 29
    //Noah, 31
    //Simo, 16
    //older
    //20
    //name age
    //
    //Output
    //
    //Lucas - 20
    //Mia - 29
    //Noah - 31


    class Filter_By_Age
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var namesAge = Console.ReadLine()
                    .Split(", ",
                        StringSplitOptions.RemoveEmptyEntries);
                persons.Add(new Person(namesAge[0],
                    int.Parse(namesAge[1])));
            }

            var filterText = Console.ReadLine();
            var ageText = int.Parse(Console.ReadLine());

            Func<Person, bool> filterFunc = filterText switch
            {
                "older" => x => x.Age >= ageText,
                "younger" => x => x.Age < ageText,
                _ => null
            };

            var outputFormat = Console.ReadLine();

            Func<Person, string> outputFunc = outputFormat switch
            {
                "name age" => c => $"{c.Name} - {c.Age}",
                "name" => c => $"{c.Name}",
                "age" => c => $"{c.Age}",
                _ => null
            };

            persons.Where(filterFunc)
                .Select(outputFunc)
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
