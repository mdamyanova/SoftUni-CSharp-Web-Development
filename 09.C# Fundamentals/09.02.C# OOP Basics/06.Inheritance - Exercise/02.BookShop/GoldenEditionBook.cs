namespace _02.BookShop
{
    public class GoldenEditionBook : Book
    {
        public override decimal Price => base.Price + (base.Price * 0.3m);

        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {

        }
    }
}