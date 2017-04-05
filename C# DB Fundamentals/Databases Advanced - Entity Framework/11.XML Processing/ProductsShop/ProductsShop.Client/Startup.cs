using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.Client
{
    public class Startup
    {
        public static void Main()
        {
            var context = new ProductsShopContext();

            // 03. Import data
            //ImportUsers(context);
            //ImportProducts(context);
            //ImportCategories(context);

            // 04. Query and export data
            //GetProductsInRange(context);
            //GetSuccessfullySoldProducts(context);
            //GetCategoriesByProductsCount(context);
            //GetUsersAndProducts(context);
            
        }

        private static void ImportUsers(ProductsShopContext context)
        {
            XDocument usersXml = XDocument.Load("../../import/users.xml");
            var users = usersXml.Root.Elements();
            foreach (var user in users)
            {
                int age;
                var number = int.TryParse(user.Attribute("age")?.Value, out age);

                var currUser = new User()
                {
                    FirstName = user.Attribute("first-name")?.Value,
                    LastName = user.Attribute("last-name").Value,
                    Age = number ? (int?) age : null
                };

                context.Users.Add(currUser);
                context.SaveChanges();
            }        
        }

        private static void ImportProducts(ProductsShopContext context)
        {
            var productsXml = XDocument.Load("../../import/products.xml");
            var products = productsXml.Root.Elements();
            var random = new Random();
            var countUsers = context.Users.Count();

            foreach (var product in products)
            {
                var buyer = random.Next(1, countUsers);
                var seller = random.Next(1, countUsers);
                var currProduct = new Product()
                {
                    Name = product.Element("name").Value,
                    Price = decimal.Parse(product.Element("price").Value),
                    Buyer = context.Users.FirstOrDefault(c => c.Id == buyer),
                    Seller = context.Users.FirstOrDefault(c => c.Id == seller)
                };

                context.Products.Add(currProduct);
                context.SaveChanges();
            }
        }

        private static void ImportCategories(ProductsShopContext context)
        {
            var categoriesXml = XDocument.Load("../../import/categories.xml");
            var categories = categoriesXml.Root.Elements();
            var products = context.Products.ToList();
            var random = new Random();

            foreach (var category in categories)
            {
                var currCategory = new Category()
                {
                    Name = category.Element("name").Value
                };

                int productsCount = context.Products.Count();
                for (int i = 0; i < 5; i++)
                {
                    int number = random.Next(1, productsCount);
                    currCategory.Products.Add(products[number]);
                }

                context.Categories.Add(currCategory);
                context.SaveChanges();
            }
        }

        private static void GetProductsInRange(ProductsShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 1000 && p.Price <= 2000
                                                       && p.BuyerId != null)
                .OrderBy(d => d.Price)
                .Select(c => new
                {
                    Name = c.Name,
                    Price = c.Price,
                    Buyer = c.Buyer.FirstName + " " + c.Buyer.LastName
                })
                .ToList();

            var xml = new XElement("products", products
                    .Select(x => new XElement("product",
                        new XAttribute("name", x.Name),
                        new XAttribute("price", x.Price),
                        new XAttribute("buyer", x.Buyer))))
                .ToString();


            Console.WriteLine(xml);
        }

        private static void GetSuccessfullySoldProducts(ProductsShopContext context)
        {
            var users = context.Users
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .Select(c => new
                {
                    FirstName = c.FirstName ?? string.Empty,
                    LastName = c.LastName,
                    SoldProducts = c.SoldProducts.Select(s => new
                    {
                        Name = s.Name,
                        Price = s.Price
                    })
                })
                .ToList();

            var xml = new XElement("users", users.Select(x => new XElement("product",
                x.FirstName == null ? null : new XAttribute("first-name", x.FirstName),
                new XAttribute("last-name", x.LastName),
                new XElement("sold-products", x.SoldProducts
                    .Select(s => new XElement("product",
                        new XElement("name", s.Name), new XElement("price", s.Price)
                    )))))).ToString();

            Console.WriteLine(xml);
        }

        private static void GetCategoriesByProductsCount(ProductsShopContext context)
        {
            var categories = context.Categories.Select(c => new
                {
                    Name = c.Name,
                    Products = c.Products,
                    AveragePrice = c.Products.Average(s => s.Price),
                    TotalPrice = c.Products.Sum(s => s.Price)
                })
                .OrderBy(d => d.Products.Count)
                .ToList();

            var xml = new XElement("categories", categories.Select(x => new XElement("category",
                new XAttribute("name", x.Name),
                new XElement("products-count", x.Products.Count),
                new XElement("aveerage-price", x.AveragePrice),
                new XElement("total-price", x.TotalPrice)
                ))).ToString();

            Console.WriteLine(xml);
        }

        private static void GetUsersAndProducts(ProductsShopContext context)
        {
            var users = context.Users.Where(c => c.SoldProducts.Count > 1)
                .OrderByDescending(c => c.SoldProducts.Count)
                .ThenBy(c => c.LastName)
                .Select(c => new
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Products = c.SoldProducts.Select(s => new
                    {
                        Name = s.Name,
                        Price = s.Price
                    })
                }).ToList();

            var xml = new XElement("users", new XAttribute("count", users.Count),
                users.Select(s => new XElement("user",
                    s.FirstName == null ? null : new XAttribute("first-name", s.FirstName),
                    new XAttribute("last-name", s.LastName),
                    new XElement("sold-products", s.Products.Select(c =>
                        new XElement("product", new XAttribute("name", c.Name),
                            new XAttribute("price", c.Price)
                        )))))).ToString();

            Console.WriteLine(xml);
        }
    }
}