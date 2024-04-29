using System;
using System.Collections.Generic;

namespace Task002
{
    // Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
    // продукции. Из коллекции можно получать категории товаров, которые купил покупатель или по
    // категории определить покупателей.

    public class Customer
    {
        string name, id;
        public Customer(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public string Name
        {
            get { return name; }
        }

        public string Id
        {
            get { return id; }
        }
    }

    public class Category
    {
        string name, id;
        public Category(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public string Name
        {
            get { return name; }
        }
            
        public string Id 
        {
            get {return id;}
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new Dictionary<Customer, List<Category>>();
            collection.Add(new Customer("Ivan", "01"), new List<Category>() { new Category("IT"    , "01"),
                                                                              new Category("Phones", "02"),
                                                                              new Category("Tools" , "03"),
                                                                              new Category("Toys"  , "01")});

            collection.Add(new Customer("Jack", "02"), new List<Category>() { new Category("IT"    , "01"),
                                                                              new Category("Phones", "02"),
                                                                              new Category("Tools" , "03"),});

            collection.Add(new Customer("John", "03"), new List<Category>() { new Category("IT"    , "01"),});

            foreach (var element in collection)
            {
                Console.WriteLine($"{element.Key.Name}:");
                foreach (var category in element.Value)
                {
                    Console.WriteLine($"{" ",3} {"-"} {category.Name}");
                }
                Console.WriteLine(new String('*', 10));
            }

            foreach (var cat in GetCustomersByCategory(collection, "IT"))
            {
                Console.WriteLine(cat.Name.ToString());
            }

        }
        public static List<Customer> GetCustomersByCategory(Dictionary<Customer, List<Category>> dic, string category)
        {
            List<Customer> result = new List<Customer>();
            foreach (var customer in dic)
            {
                foreach (var cat in customer.Value)
                {
                    if (cat.Name.Equals(category))
                    {
                        result.Add(customer.Key);
                    }
                }
            }
            return result;
        }
    }
}
