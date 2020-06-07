using System;
using System.Security.Cryptography.X509Certificates;
using _01._Library;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main()
        {
            var catCollection = new CatCollection
                {
                    new CuteCat {Name = "Pesho"},
                    new CuteCat {Name = "Ivan"}

                };

            foreach (var cats in catCollection)
            {
                Console.WriteLine(cats.Name);
            }

            var coolStack = new CoolStack<int>();
            coolStack.Push(3);
            coolStack.Push(5);
            coolStack.Push(10);
            coolStack.Push(7);
            coolStack.Push(25);
            foreach (var stack in coolStack)
            {
                Console.WriteLine(stack);
            }

            var coolList = new CoolLinkedList<int>();
            coolList.AddHead(1);
            coolList.AddHead(2);
            coolList.AddHead(3);
            coolList.AddHead(4);
            foreach (var i in coolList)
            {
                Console.WriteLine(i);
            }
            SomeMethodsWithParams(1, new[] { "1", "1", "1" });
            SomeMethodsWithParams(2, new[] { "1", "2" });
            SomeMethodsWithParams(3, new[] { "3" });
            SomeMethodsWithParams(5, "3" );
            SomeMethodsWithParams(5,"3", "3", "3");
            SomeMethodsWithParams(6, "3", "2", "445");
            SomeMethodsWithParams(6);

        }
        public static void SomeMethodsWithParams(int a, params string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {

            }
        }

    }
}
