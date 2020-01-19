using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int lineCounter = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine($"{lineCounter} {line}");
                        lineCounter++;
                    }               
                }
            }
        }
    }
}
