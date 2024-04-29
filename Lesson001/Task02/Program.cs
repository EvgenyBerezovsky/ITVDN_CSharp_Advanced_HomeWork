using System;

// Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
// количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по
// порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
// только один месяц.

namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isLeanYear = true;
            Year year = new Year(isLeanYear);

            foreach (var item in year)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 10));
            Console.WriteLine(year.GetDaysByMonth(5));

            Console.WriteLine(new string('-', 10));
            Console.WriteLine(year.GetMonthByDays(30));
            Console.ReadKey();
        }
    }
}
