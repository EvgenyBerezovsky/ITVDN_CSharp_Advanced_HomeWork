using System;
using System.IO;
// Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их.
namespace Task001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directoriInfo =
            new DirectoryInfo(@"D:\ITVDN\ITVDN_C#_Advanced_HomeWork\Lesson003\Task001");
            for (int i = 0; i < 100; i++)
            {
                directoriInfo.CreateSubdirectory($"Folder_{i}");
            }
            
            Console.ReadKey();

            for (int i = 0; i < 100; i++)
            {
                Directory.Delete(String.Format(@"D:\ITVDN\ITVDN_C#_Advanced_HomeWork\Lesson003\Task001\Folder_{0}", i));
            }
        }
    }
}
