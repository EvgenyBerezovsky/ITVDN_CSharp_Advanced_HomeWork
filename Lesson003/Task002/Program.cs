using System;
using System.IO;

namespace Task002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"D:\ITVDN\ITVDN_C#_Advanced_HomeWork\Lesson003\Task002\TestDirectory";
            Directory.CreateDirectory(directoryPath);

            FileInfo fileInfo = new FileInfo(directoryPath + "\\MyTextFile.txt");
            FileStream fileStream = fileInfo.OpenWrite();
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("Hello World!!!!!!!");
            streamWriter.Close();

            StreamReader streamReader = new StreamReader(directoryPath + @"\MyTextFile.txt");
            string result = streamReader.ReadLine();
            streamReader.Close();
            Console.WriteLine(result);

            Console.ReadKey();

            fileInfo.Delete();
            Directory.Delete(directoryPath);
        }
    }
}
