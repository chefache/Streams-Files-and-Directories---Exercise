using System;
using System.IO;

namespace Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            var totalSize = new FileInfo("Work File.txt").Length;
            var sizePerFile = (int)Math.Ceiling(totalSize / 5.0);

            using (var reader = new FileStream("Work File.txt", FileMode.Open))
            {
                for (int i = 1; i <= n; i++)
                {
                    var buffer = new byte[sizePerFile];
                    var readBytes = reader.Read(buffer, 0, sizePerFile);

                    using (var writer = new FileStream($"file-{i}.txt", FileMode.OpenOrCreate))
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }           
        }
    }
}
