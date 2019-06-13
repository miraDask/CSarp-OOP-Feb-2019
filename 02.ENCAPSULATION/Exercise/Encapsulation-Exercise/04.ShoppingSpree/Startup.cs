namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            foreach (var person in peopleData)
            {
                string[] personData = person.Split('=');
                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                try
                {
                    Person currentPerson = new Person(name, money);
                    people.Add(currentPerson);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();

            foreach (var product in productsData)
            {
                string[] productData = product.Split('=');
                var name = productData[0];
                var cost = decimal.Parse(productData[1]);

                try
                {
                    Product currentProduct = new Product(name, cost);
                    products.Add(currentProduct);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] personProductData = input.Split();

                var personName = personProductData[0];
                var productName = personProductData[1];

                if (people.Any(x => x.Name == personName) && products.Any(x => x.Name == productName))
                {
                    var person = people.Find(x => x.Name == personName);
                    var product = products.Find(x => x.Name == productName);

                    if (person.AddProduct(product))
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
