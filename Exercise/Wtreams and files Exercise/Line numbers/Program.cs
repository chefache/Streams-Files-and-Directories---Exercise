using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCounter = 0;
            int punctoationCounter = 0;
            int letterCounter = 0;
            var punctoationElements = new[] { '.', ',', '?', '!', '-' };
            string output = string.Empty;

            var sb = new StringBuilder();

            using (var reader = new StreamReader("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lineCounter++;
                    output = $"Line {lineCounter}:{line}";

                    for (int i = 0; i < line.Length; i++)
                    {
                        char lineElement = line[i];

                        if ((lineElement >= 'a' && lineElement <= 'z') || (lineElement >= 'A' && lineElement <= 'Z'))
                        {
                            letterCounter++;
                        }
                        if (punctoationElements.Contains(lineElement))
                        {
                            punctoationCounter++;
                        }
                       
                    }

                    string finalOutput = ($"{output}({letterCounter})({punctoationCounter})");
                    Console.WriteLine(finalOutput);
                    sb.AppendLine(finalOutput);

                    File.WriteAllText("output.txt", sb.ToString().TrimEnd());
                  
                    punctoationCounter = 0;
                    letterCounter = 0;
                   
                }
               
            }
        }
    }
}
