using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Task004
{
//    Создайте текстовый файл-чек по типу «Наименование товара – 0.00 (цена) грн.» с
//   определенным количеством наименований товаров и датой совершения покупки.Выведите на
//   экран информацию из чека в формате текущей локали пользователя и в формате локали en-
//   US.
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\ITVDN\ITVDN_C#_Advanced_HomeWork\Lesson004\Task004\Receipt\Receipt.txt";
            string receipt = File.ReadAllText(path, Encoding.UTF8);

            var myCulture = CultureInfo.CurrentCulture;
            var usCulture = new CultureInfo("en-US");

            string pattern = @"\s\d+[\.\,]\d+";

            string receiptMyCulture = Regex.Replace(receipt, pattern, (m) => double.Parse(m.Value.Replace('.', ',')).ToString("C", myCulture));
            string receiptUsCulture = Regex.Replace(receipt, pattern, (m) => double.Parse(m.Value.Replace('.', ',')).ToString("C", usCulture));

            Console.WriteLine(receiptMyCulture);
            Console.WriteLine(new String('*', 50));
            Console.WriteLine(receiptUsCulture);
        }
    }
}