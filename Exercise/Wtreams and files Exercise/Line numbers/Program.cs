using System;
using System.IO;
using System.Linq;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesCounter = 1;
            var punctoationsCounter = 0;
            var letterCounter = 0;

            var punctoations = new[] { '-', '.', ',', '!', '?' };

            using (var reader = new StreamReader("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToCharArray();
                    linesCounter++;

                    for (int i = 0; i < line.Length; i++)
                    {
                        letterCounter++;
                        var currentSymbol = line[i];

                        foreach (var punctoationMark in punctoations)
                        {
                            if (currentSymbol == punctoationMark)
                            {
                                letterCounter--;
                                punctoationsCounter++;
                            }
                        }
                    }
                   



                    var resultLine = $"Line {linesCounter}: {line}";

                }
            }
        }
    }
}
