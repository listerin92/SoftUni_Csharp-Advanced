using System.Collections.Generic;

namespace _01_Library
{
    public class Book
    {
        public Book(string title, int year, List<string> authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }

    }
}
