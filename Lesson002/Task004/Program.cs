using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Task004
{
    public class MyClass
    {
        public int IntProp { get; set; }
        public double DoubleProp { get; set; }
    }

    public class MyClassComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            MyClass item1 = x as MyClass;
            MyClass item2 = y as MyClass;
            return item1.IntProp == item2.IntProp;
        }

        public int GetHashCode(object obj)
        {
            return (obj as MyClass).IntProp;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary myDictionary = new OrderedDictionary(new MyClassComparer());
            try
            {
                myDictionary.Add(new MyClass() { IntProp = 1, DoubleProp = 1.11 }, "Item1");
                myDictionary.Add(new MyClass() { IntProp = 2, DoubleProp = 2.11 }, "Item2");
                myDictionary.Add(new MyClass() { IntProp = 3, DoubleProp = 3.11 }, "Item3");
                myDictionary.Add(new MyClass() { IntProp = 4, DoubleProp = 4.11 }, "Item4");
                myDictionary.Add(new MyClass() { IntProp = 3, DoubleProp = 5.11 }, "Item5");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (DictionaryEntry item in myDictionary)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
