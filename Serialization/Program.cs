using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int[] Grades { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student();

            student.Name = "Stefan";
            student.Age = 34;
            student.Grades = new[] { 3, 4, 5, 3, 4 };

            var formatter = new BinaryFormatter();
            using (var stream = new FileStream("studentInfo.txt",FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(stream, student);
            }

            using (var reader = new FileStream("studentInfo.txt", FileMode.OpenOrCreate))
            {
                var dataBuffer = new byte[300];

                reader.Read(dataBuffer, 0, dataBuffer.Length);
            }
        }
    }
}
