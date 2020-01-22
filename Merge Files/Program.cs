using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            using (var reader = new StreamReader("input1.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(int.Parse(line));
                }
            }
            using (var reader = new StreamReader("input2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(int.Parse(line));
                }
            }
            using (var writer = new StreamWriter("output.txt"))
            {
                foreach (var num in list.OrderBy(x => x))
                {
                    writer.WriteLine(num);
                }
            }
        }
    }
}
