using System;
using System.IO;

namespace CalculateFolderSize
{
    class CalculateFolderSize
    {
        static void Main(string[] args)
        {
            var path = $@"J:\OneDrive\Documents\SoftUNI\SoftUni_Csharp-Advanced2\Streams Files And Directories\4.Merge Files\bin\Debug\netcoreapp3.1";
            var files = Directory.GetFiles(path);
            var totalSize = 0m;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            Console.WriteLine($"{totalSize / 1024 / 1024:F4} MB");
        }
    }
}
