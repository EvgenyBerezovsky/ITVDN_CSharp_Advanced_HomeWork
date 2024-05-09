using System.Text.RegularExpressions;

namespace Task003
{
//    Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
//    заменить все предлоги на слово «ГАВ!».
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"C:\Users\Evgen\Documents\TestTextFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            String input = reader.ReadToEnd();
            reader.Close();
            stream.Close();

            string pattern = @"\s[\w]{1,3}\s";

            string output = Regex.Replace(input, pattern, "Hello!!!");
            stream = new FileStream(@"C:\Users\Evgen\Documents\TestTextFile.txt", FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(output);
            writer.Close();
            stream.Close();
        }
    }
}