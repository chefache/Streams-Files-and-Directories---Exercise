using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {           
            using (var reader = new StreamReader("input.txt"))
            {
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine();
                    }
                    counter++;
                }
            }
        }
    }
}
