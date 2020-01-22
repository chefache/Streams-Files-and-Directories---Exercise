using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordCount = new Dictionary<string, int>();

            var searchedWords = Console.ReadLine()
                .ToLower()
                .Split();

            using (var readetText = new StreamReader("input.txt"))
            {
                while (!readetText.EndOfStream)
                {
                    var line = readetText.ReadLine().ToLower();

                    var regexRools = new Regex(@"\b[A-Za-z]{2,}");

                    var matches = regexRools.Matches(line);

                    foreach (var match in matches)
                    {
                        foreach (var word in searchedWords)
                        {
                            if (match.ToString() == word.ToString())
                            {
                                if (!wordCount.ContainsKey(word))
                                {
                                    wordCount.Add(word, 0);
                                }

                                wordCount[word]++;
                            }
                        }
                    }
                }

                using (var writer = new StreamWriter("output.txt"))
                {
                    foreach (var word in wordCount.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
