namespace GickasStore
{
    public class Startup
    {
        private static void Main()
        {
            Product milk = new Product("Milk", "Milkinis 00D", "Cow milk", 2.00M)
            {
                Quantity = 3,
                Weight = 4
            };
            //Product cheese = new Product("White cheese", "Cheese and wine", "Delicateses for the soul", 10.00M);
            //Product tomato = new Product("Bulgarian tomatoes", "VegsAndFruits E00D", "Big red tomatoes", 4.00M);


            GickasStoreContext context = new GickasStoreContext();
            context.Products.Add(milk);
            context.Products.Remove(context.Products.Find(1));
            //context.Products.Add(cheese);
            //context.Products.Add(tomato);

            context.SaveChanges();
        }
    }
}