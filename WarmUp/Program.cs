using System;
using System.IO;
using System.Text;

namespace WarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory); //показва текучата директория на приложението;

            using (StreamWriter writer = new StreamWriter("myTextFile.txt"))
            {
                for (int i = 0; i <= 10; i++)
                {
                    writer.WriteLine("Number: " + i);
                }
            }

            using (var reader = new StreamReader("myTextFile.txt"))
            {
                while (!reader.EndOfStream) //"докато файла не е приключил, четем";
                {
                    var reader2 = reader.ReadLine();
                    Console.WriteLine(reader2);
                }
            }


            /////////////////////////////////////////////////////////////////////////////

            // Писане във bynary file;
            byte[] bytes = { 48, 49, 50, 51 };  // това са bytes;
            using (var binariWryter = new FileStream("myFile.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                binariWryter.Write(bytes, 0, bytes.Length); // 0 - offset, казва колко да се премести главата надясно преди да пиша;
            }

            // Четене от bynary file;
            using (var binariReader = new FileStream("myFile.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                binariReader.Seek(1, SeekOrigin.Begin); //Seek казва на четеца да започне от 1 позиция в дясно от началото;

                var buffer = new byte[4];
                var read = binariReader.Read(buffer, 0, buffer.Length);
                Console.WriteLine(read);
            }

            // Конвертиране с енкодинг;
            // на текст в bytes;
            var text = Encoding.UTF8.GetBytes(Console.ReadLine());
            Console.WriteLine(string.Join(", ", text));
            // на bytes в текст;
            var secondText = Encoding.UTF8.GetString(text);
            Console.WriteLine("text again: " + " " + secondText);
        }
    }
}
