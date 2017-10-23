namespace Sales.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Sales.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sales.SalesContext";
        }

        protected override void Seed(Sales.SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "Car", Description = "Vehicle" });
            context.Products.AddOrUpdate(new Product() { Name = "Motorcycle", Description = "Vehicle" });
            context.Products.AddOrUpdate(new Product() { Name = "Truck", Description = "Vehicle" });

            context.Customers.AddOrUpdate(new Customer() { FirstName = "Ivan", LastName = "Dimitrov" });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Pesho", LastName = "Petkov" });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Todor", LastName = "Georgiev" });
        }
    }
}