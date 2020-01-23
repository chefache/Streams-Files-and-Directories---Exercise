using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfSearchedWords = new List<string>();
            var wordsCounter = new Dictionary<string, int>();
            var sb = new StringBuilder();

            using (var searchedWordsReader = new StreamReader("words.txt"))
            {
                while (!searchedWordsReader.EndOfStream)
                {
                    var word = searchedWordsReader.ReadLine()
                        .ToLower();

                    listOfSearchedWords.Add(word);
                }

                using (var textReader = new StreamReader("text.txt"))
                {
                    while (!textReader.EndOfStream)
                    {
                        var singleTextLine = textReader.ReadLine()
                            .ToLower();

                        var textValidator = new Regex(@"\b[a-z]{2,}");

                        var validatedText = textValidator.Matches(singleTextLine);

                        validatedText.ToString().Split();

                        for (int i = 0; i < listOfSearchedWords.Count; i++)
                        {
                            var searchedWord = listOfSearchedWords[i];

                            foreach (var wordFromText in validatedText)
                            {
                                if (searchedWord == wordFromText.ToString())
                                {
                                    if (!wordsCounter.ContainsKey(searchedWord))
                                    {
                                        wordsCounter.Add(searchedWord, 0);
                                    }
                                    wordsCounter[searchedWord]++;
                                }
                            }
                        }

                    }
                }
               foreach (var item in wordsCounter.OrderByDescending(x => x.Key))
               {
                   var textToWrite = ($"{item.Key} - {item.Value}");
              
                   sb.AppendLine(textToWrite);
              
                   File.WriteAllText("actualResult.txt", sb.ToString().TrimEnd());
               }

                sb.Clear();

                foreach (var item in wordsCounter.OrderByDescending(x => x.Value))
                {
                    var textToWrite = ($"{item.Key} - {item.Value}");                  
                    sb.AppendLine(textToWrite);

                    File.WriteAllText("expectedResult.txt", sb.ToString().TrimEnd());
                }
            }
        }
    }
}
