

namespace _01.BookShop
{
    public class GoldenEditionBook : Book
    {
        public override double Price => base.Price+(base.Price*0.3);

        public GoldenEditionBook(string title, string author, double price) 
            : base(title, author, price)
        {
            
        }
    }
}