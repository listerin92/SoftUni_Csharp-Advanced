using System;
using System.Collections.Generic;

namespace _01_Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            var library = new Library
            {
                new Book("To", 1992, new List<string> {"Steven King"}),
                new Book("Amazon", 2002, new List<string> {"Pesho King"})
            };

            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}