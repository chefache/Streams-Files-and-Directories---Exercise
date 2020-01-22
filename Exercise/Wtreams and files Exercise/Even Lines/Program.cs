using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("text.txt"))
            {
                var charsForChange = new[] { "-", ",", ", ", ".", "!", "?" };
                int counter = 0;

                var sb = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (counter % 2 == 0)
                    {
                        var words = line.Split();

                        for (int i = 0; i < words.Length; i++)
                        {
                            var currentWord = words[i];

                            foreach (var symbol in charsForChange)
                            {
                                currentWord = currentWord.Replace(symbol, "@");
                            }

                            words[i] = currentWord;
                        }
                        var result = string.Join(" ", words.Reverse());
                        sb.AppendLine(result);

                        File.WriteAllText("output.txt", sb.ToString().TrimEnd());
                    }

                    counter++;
                }
            }
            ;
        }
    }
}
