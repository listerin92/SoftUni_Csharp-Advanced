using System;
using System.IO;

namespace directoryPlay
{
    class directoryPlay
    {
        static void Main(string[] args)
        {
            var path = $@"J:\OneDrive\Documents\SoftUNI\SoftUni_Csharp-Advanced2";
            PrintDirectory(path, string.Empty);
        }

        static void PrintDirectory(string path, string prefix)
        {
            var directories = Directory.GetDirectories(path);
            var directoryInfo = new DirectoryInfo(path);
            var files = Directory.GetFiles(path);

            Console.WriteLine($"{prefix} Dir: {directoryInfo.Name}");

            foreach (var directory in directories)
            {
                PrintDirectory(directory, prefix+="--");
            }

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine($"{prefix} File: {fileInfo.Name}");
            }
        }
    }
}
