using System;
using System.IO;
using System.Text.Unicode;

namespace Streams
{
    class _1_Odd_Lines
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("text.txt");
            using var writer = new StreamWriter("output.txt");
            int count = 0;
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (count % 2 == 1)
                {
                    writer.WriteLine(line);
                }
                count++;
            }

        }
    }
}
