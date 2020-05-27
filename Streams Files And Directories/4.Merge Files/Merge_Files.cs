using System;
using System.IO;

namespace _4.Merge_Files
{
    class Merge_Files
    {
        static void Main(string[] args)
        {
            using var input1 = new StreamReader("Input1.txt");
            using var input2 = new StreamReader("Input2.txt");
            using var output = new StreamWriter("Output.txt");
            
            while (true)

            {
                var line1 = input1.ReadLine();
                var line2 = input2.ReadLine();
                if (line1 == null || line2 == null)
                {
                    break;
                }

                output.WriteLine(line1);
                output.WriteLine(line2);
            }
            
        }
    }
}
