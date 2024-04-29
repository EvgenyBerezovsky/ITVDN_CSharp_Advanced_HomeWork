using System;
using System.Collections;

namespace Task001
{
    // Используя класс SortedList, создайте небольшую коллекцию и выведите на экран значения пар
    // «ключ- значение» сначала в алфавитном порядке, а затем в обратном.
    internal class Program
    {
        public class DescendingComparer : IComparer
        {
            CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

            public int Compare(object x, object y)
            {
                return comparer.Compare(y, x);
            }
        }
        static void Main(string[] args)
        {
            var mySortedList = new SortedList();
            mySortedList["A"] = "1st";
            mySortedList["D"] = "4nd";
            mySortedList["B"] = "2rd";
            mySortedList["C"] = "3th";

            foreach (DictionaryEntry entry in mySortedList)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }

            Console.WriteLine(new String('*', 8));
            var sortRevers = new SortedList(new DescendingComparer());

            sortRevers["A"] = "1st";
            sortRevers["D"] = "4nd";
            sortRevers["B"] = "2rd";
            sortRevers["C"] = "3th";

            foreach (DictionaryEntry entry in sortRevers)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
