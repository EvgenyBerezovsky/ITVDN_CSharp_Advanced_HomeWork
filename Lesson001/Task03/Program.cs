using System;
using System.Collections.Generic;
using System.ComponentModel;

// Создайте абстрактный класс Гражданин. Создайте классы Студент, Пенсионер, Рабочий
// унаследованные от Гражданина. Создайте непараметризированную коллекцию со следующим
// функционалом:
// 1. Добавление элемента в коллекцию.
//    1) Можно добавлять только Гражданина.
//    2) При добавлении, элемент добавляется в конец коллекции. Если Пенсионер, – то в
//       начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
//    3) При добавлении одного и того же человека (проверка на равенство по номеру
//       паспорта, необходимо переопределить метод Equals и/или операторы равенства для
//       равнения объектов по номеру паспорта) элемент не добавляется, выдается
//       ообщение.
// 2. Удаление
//    1) Удаление – с начала коллекции.
//    2) Возможно удаление с передачей экземпляра Гражданина.
// 3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
//    номер в очереди.
// 4. Метод ReturnLast возвращsает последнего чеолвека в очереди и его номер в очереди.
// 5. Метод Clear очищает коллекцию.
// 6. С коллекцией можно работать опертаором foreach.

namespace Task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyCollection citizens = new MyCollection();
            //citizens.Add(new Student("Alex", "Po", "IM000111"));
            //citizens.Add(new Worker("Bob", "Snob", "EK 333444"));
            //citizens.Add(new Worker("Pol", "Dupol", "EK000222"));
            //citizens.Add(new Student("Alex1", "Po1", "IM0001111"));
            //citizens.Add(new Pensioner("Pensioner1", "Snob1", "EK 3334441"));
            //citizens.Add(new Pensioner("Pensioner2", "Dupol1", "EK0002221"));
            //foreach (Citizen item in citizens)
            //{
            //    Console.WriteLine(item.Name);
            //}

            MyCollection citizens = new MyCollection();
            int index;

            Console.WriteLine("Добавление элементов в коллекцию");
            citizens.Add(new Student("Alex", "Po", "IM000111"));
            citizens.Add(new Pensioner("Bob", "Snob", "ek333444"));
            citizens.Add(new Worker("Pol", "Dupol", "EK000222"));
            citizens.Add(new Pensioner("Bob2", "Snob2", "ek333444")); // Добавления не произойдет, т.к. уже есть элемент с таким номером паспорта
            Pensioner p3 = new Pensioner("Bob3", "Snob3", "em222777");
            citizens.Add(p3);

            foreach (Citizen item in citizens)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('*', 30));

            Pensioner p4 = new Pensioner("Bob4", "Snob4", "em444111"); // В коллекцию не добавляем
            Console.WriteLine("В коллекции есть {0} - {1}, его позиция {2} ", p3.Name, citizens.Contains(p3, out index), index);
            Console.WriteLine("В коллекции есть {0} - {1}, его позиция {2} ", p4.Name, citizens.Contains(p4, out index), index);
            Console.WriteLine(new string('*', 30));

            Console.WriteLine("Кто последний? - {0}, позиция {1}", citizens.ReturnLast(out index).Name, index);
            Console.WriteLine(new string('*', 30));

            Console.WriteLine("Удаление элементов из коллекции");
            citizens.Remove(p3);
            citizens.Remove(p4);
            citizens.RemoveFirst();
            foreach (Citizen item in citizens)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('*', 30));

            citizens.Clear();
            if (citizens.Count == 0)
            {
                Console.WriteLine("Коллекция очищена");
            }

            Console.ReadKey();
        }
    }
}
