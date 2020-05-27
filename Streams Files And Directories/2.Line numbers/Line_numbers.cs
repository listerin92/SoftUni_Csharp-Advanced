using System;
using System.IO;
using System.Text;

namespace _2.Line_numbers
{
    class Line_numbers
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("text.txt");
            using var writer = new StreamWriter("output.txt");
            int count = 1;
            StringBuilder str = new StringBuilder();
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                str.Append($"{count}. {line}");
                writer.WriteLine(str);
                str.Clear();
                count++;
            }

        }
    }
}
