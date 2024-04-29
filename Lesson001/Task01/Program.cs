using System;
using System.Collections;
using System.Collections.Generic;

// Создайте метод, который в качестве аргумента принимает массив целых чисел и возвращает
// коллекцию квадратов всех нечетных чисел массива. Для формирования коллекции
// используйте оператор yield.

namespace Task01
{
    internal class Program
    {
        public static IEnumerable GetSpecifiedCollection(int[] source)
        {
            foreach (int i in source)
                if (i % 2 == 0) yield return i * i;
        }

        public static int[] GetArray(int count)
        {
            int[] result = new int[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                result[i] = random.Next(0, 100);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] source = GetArray(20);
            var collection = GetSpecifiedCollection(source);

            foreach (int i in collection)
            Console.Write(i.ToString() + ", ");
        }
    }
}
