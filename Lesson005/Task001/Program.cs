using System.Xml;

namespace Task001
{
    internal class Program
    {
        //      Создайте.xml файл, который соответствовал бы следующим требованиям:
        //  - имя файла: TelephoneBook.xml
        //  - корневой элемент: “MyContacts”
        //  - тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber”
        //    со значением номера телефона.
        static void Main(string[] args)
        {
            Dictionary<string, string> myTelephoneBook = new Dictionary<string, string>()
            {
                {"Contact1", "+380681111111" },
                {"Contact2", "+380682222222" },
                {"Contact3", "+380683333333" },
                {"Contact4", "+380684444444" },
                {"Contact5", "+380685555555" },
                {"Contact6", "+380686666666" },
                {"Contact7", "+380687777777" },
                {"Contact8", "+380688888888" },
            };   

            XmlTextWriter xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);
            //xmlWriter.Formatting = Formatting.Indented;
           
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");

            foreach (var record in myTelephoneBook)
            {
                xmlWriter.WriteStartElement("Contact");
                xmlWriter.WriteStartAttribute("TelephoneNumber");
                xmlWriter.WriteString(record.Value);
                xmlWriter.WriteEndAttribute();
                xmlWriter.WriteString(record.Key);
                xmlWriter.WriteEndElement(); //"Contact"
            }
            xmlWriter.WriteEndElement();     //"MyContacts"
            xmlWriter.Close();

            XmlTextReader reader = new XmlTextReader("TelephoneBook.xml");

            while (reader.Read())
            {
                if (reader.HasAttributes)
                {
                    Console.WriteLine(reader.NodeType + " " + reader.Name + " " + reader.GetAttribute(0) + " " + reader.Value);
                }
                else
                {
                    Console.WriteLine(reader.NodeType + " " + reader.Name + " " + reader.Value);
                }
            }
            reader.Close();

            Console.WriteLine(new String('-', 10));
            reader = new XmlTextReader("TelephoneBook.xml");

            while (reader.Read())
            {
                if (reader.HasAttributes)
                {
                    Console.WriteLine(reader.GetAttribute("TelephoneNumber"));
                }
            }
            reader.Close();
        }
    }
}