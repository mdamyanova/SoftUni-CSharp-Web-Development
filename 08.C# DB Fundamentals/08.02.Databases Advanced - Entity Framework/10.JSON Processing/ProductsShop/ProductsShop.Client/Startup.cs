using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
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

            // 02. Import data
            //ImportUsers(context);
            //ImportProducts(context);
            //ImportCategories(context);

            // 03. Query and export data
            //GetProductsInRange(context);
            //GetSuccessfullySoldProducts(context);
            // GetCategoriesByProductsCount(context);
            //GetUsersAndProducts(context);
            
        }

        private static void ImportUsers(ProductsShopContext context)
        {
            string usersJson = File.ReadAllText("../../import/users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(usersJson);

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductsShopContext context)
        {
            string productsJson = File.ReadAllText("../../import/products.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (var product in products)
            {
                product.SellerId = (number % usersCount) + 1;
                number++;

                // each third product will have buyer
                if (number % 3 != 0)
                {
                    product.BuyerId = (number * 2 % usersCount) + 1;
                }
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportCategories(ProductsShopContext context)
        {
            string categoriesJson = File.ReadAllText("../../import/categories.json");
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            int number = 0;
            int productsCount = context.Products.Count();
            foreach (var category in categories)
            {
                int categoryProductsCount = number % 3;
                for (int i = 0; i < categoryProductsCount; i++)
                {
                    category.Products.Add(context.Products.Find(number % productsCount + 1));
                }
                number++;
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void GetProductsInRange(ProductsShopContext context)
        {
            var products =
                context.Products.Include("Seller").Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(
                        p =>
                            new
                            {
                                Name = p.Name,
                                Price = p.Price,
                                SellerName = (p.Seller.FirstName ?? "") + " " + p.Seller.LastName
                            });

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("../../products.json", json);
        }

        private static void GetSuccessfullySoldProducts(ProductsShopContext context)
        {
            var users = context.Users.Include("SoldProducts").Where(u => u.SoldProducts.Count() >= 1).Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProductCount = u.SoldProducts.Count,
                    SoldProduct = new
                    {
                        Count = u.SoldProducts.Count(),
                        Products = u.SoldProducts.Select(p => new {Name = p.Name, Price = p.Price})
                    }
                }
            );

            string json = JsonConvert.SerializeObject(new {UsersCount = users.Count(), Users = users},
                Formatting.Indented);
            File.WriteAllText("../../users-groups.json", json);
        }

        private static void GetCategoriesByProductsCount(ProductsShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Select(p => new
                    {
                        averagePrice = c.Products.Average(a => a.Price),
                        totalRevenue = c.Products.Sum(s => s.Price)
                    })
                })
                .OrderBy(c => c.category)
                .ToList();


            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("../../categories.json", json);
        }

        private static void GetUsersAndProducts(ProductsShopContext context)
        {
            var result = context.Users
                .Where(s => s.SoldProducts.Count > 1)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Product = u.SoldProducts
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                })
                .OrderByDescending(s => s.Product.Count())
                .ThenBy(s => s.LastName)
                .ToList();

            var usersCount = new
            {
                usersCount = result.Count(),
                result = result
            };

            var json = JsonConvert.SerializeObject(usersCount, Formatting.Indented);
            File.WriteAllText("../../users-products.json", json);
        }
    }
}