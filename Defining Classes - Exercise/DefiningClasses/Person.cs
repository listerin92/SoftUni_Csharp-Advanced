

using System;

namespace DefiningClasses
{
    public class Person
    {
        private int _age;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
        {
            this.Name = "No name";
            this.Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Age
        {
            get => _age;
            set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Not possible to set Age below 0");
                //}
                _age = value;
            }

        }
    }
}
