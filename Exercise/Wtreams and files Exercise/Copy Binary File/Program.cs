using System;
using System.IO;
using System.Linq;

namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = File.OpenRead(@"C:\\Users\stefa\OneDrive\Pictures\.NET.png"))
            {
                using (FileStream streamWriter = File.OpenWrite(@"C:\\Users\stefa\OneDrive\Pictures\FileStreamCopy"))
                {
                    BinaryReader reader = new BinaryReader(streamReader);
                    BinaryWriter writer = new BinaryWriter(streamWriter);

                    // create a buffer to hold the bytes 
                    byte[] buffer = new Byte[5000];
                    int bytesRead;

                    // while the read method returns bytes
                    // keep writing them to the output stream
                    while ((bytesRead = streamReader.Read(buffer, 0, 5000)) > 0)
                    {
                        streamWriter.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
