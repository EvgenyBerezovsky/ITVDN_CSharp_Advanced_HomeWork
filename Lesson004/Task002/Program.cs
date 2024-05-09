using System.Net;
using System.Text.RegularExpressions;

namespace Task002
{
    //    Напишите программу, которая бы позволила вам по указанному адресу web-страницы
    //    выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла
    //    полученный результат в файл.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес сайта для проверки: ");
            string? url = Console.ReadLine();

            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);

            // Get the response.
            WebResponse response = request.GetResponse();

            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            string result = reader.ReadToEnd(); 

            reader.Close();
            response.Close();

            //Console.WriteLine(result);

            StreamWriter writer = File.CreateText("Log.txt");

            var regex = new Regex(@"href=(?<link>[""]https[\:/a-zа-яA-ZА-Я0-9\.\?\=&-]*[""])");
            foreach (Match item in regex.Matches(result))
            {
                writer.WriteLine("Link: {0,-25}", item.Groups["link"]);
            }

            regex = new Regex(@"(?<phone>[+3(0-90-90-9)\s]{2,}[0-9]{3}[\s\-][0-9]{2}[\s\-][0-9]{2})");
            foreach (Match item in regex.Matches(result))
            {
                writer.WriteLine("Phone: {0,-25}", item.Groups["phone"]);
            }

            regex = new Regex(@"(?<email>[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4})");

            foreach (Match m in regex.Matches(result))
            {
                writer.WriteLine("E-Mail: {0,-25}", m.Groups["email"]);
            }

            writer.Close();

        }    
    }
}