using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SliceFile
{
    class SliceFile
    {
        static void Main(string[] args)
        {
           using var stream = new FileStream("Text.txt", FileMode.OpenOrCreate);
           var parts = 4;
           var length = (int) Math.Ceiling(stream.Length / (decimal) parts);
            var buffer = new byte[length];
            for (int i = 0; i < parts; i++)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }
                using var currentPartStream = new FileStream($"Part{i+1}.txt", FileMode.Create);
                currentPartStream.Write(buffer, 0, buffer.Length);

            }
        }
    }
}
