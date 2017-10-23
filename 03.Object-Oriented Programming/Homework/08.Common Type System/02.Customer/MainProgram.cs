using System;

namespace _02.Customer
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(
                "Ivana", 
                "Dragancheva", 
                "Koeva", 
                "6603347878",
                "Sofia",
                "088123456",
                "ivana@abv.bg",
                CustomerType.Regular);

            customer1.AddPayment(new Payment("Slanina", 4.12M));

            Customer customer2 = new Customer(
                "Pesho",
                "Tichev",
                "Savov",
                "3412541200",
                "Plovdiv",
                "0884554475",
                "baipesho@gmail.com",
                CustomerType.Diamond
                );

            customer2.AddPayment(new Payment("Books", 16.00M));

            Console.WriteLine(customer1 == customer2);

            var customer3 = (Customer) customer1.Clone();
            customer3.AddPayment(new Payment("House", 50000M));

            Console.WriteLine(customer1);
            Console.WriteLine(customer2);
            Console.WriteLine(customer3);

            var compare = customer3.CompareTo(customer1);
            Console.WriteLine(compare);
        }
    }
}