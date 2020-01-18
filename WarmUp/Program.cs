using System;
using System.IO;

namespace WarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine(Environment.CurrentDirectory); //показва текучата директория на приложението;

            StreamWriter writer = new StreamWriter("myTextFile.txt");
            writer.Write("Hello world!");
            writer.Close();
        }
    }
}
