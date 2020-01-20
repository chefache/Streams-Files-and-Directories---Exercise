using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var totalLenght = 0L;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                totalLenght += fileInfo.Length;
            }
            Console.WriteLine(totalLenght);
        }
    }
}
