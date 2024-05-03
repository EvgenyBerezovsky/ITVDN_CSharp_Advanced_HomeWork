using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

//  Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
//  вещественные значения, по типу «счет предприятия – доступная сумма» соответственно.
namespace Task003
{
    internal class Program
    {
        public static Dictionary<int, double> GetDictionary(int count)
        {
            Dictionary<int, double> result = new Dictionary<int, double>();
            while (result.Count < count) 
            {
                int someInt = new Random().Next(0, 100);
                double someDouble = new Random().Next(1, 100) / 3d ;
                if (!result.ContainsKey(someInt))
                result.Add(someInt, someDouble);
            }
            return result;
        }
        public static SortedDictionary<int, double> GetSortedDictionary(int count)
        {
            SortedDictionary<int, double> result = new SortedDictionary<int, double>();
            while (result.Count < count)
            {
                int someInt = new Random().Next(0, 100);
                double someDouble = new Random().Next(1, 100) / 3d;
                if (!result.ContainsKey(someInt))
                    result.Add(someInt, someDouble);
            }
            return result;
        }
        public static void PrintCollection(IDictionary<int, double> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(@" {0} - {1:f4}", item.Key, item.Value);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<int, double> dictionary = GetDictionary(10);
            SortedDictionary<int, double> sortedDictionary = GetSortedDictionary(20);

            PrintCollection(dictionary);
            Console.WriteLine(new string('*', 15));
            PrintCollection(sortedDictionary);
        }
    }
}
