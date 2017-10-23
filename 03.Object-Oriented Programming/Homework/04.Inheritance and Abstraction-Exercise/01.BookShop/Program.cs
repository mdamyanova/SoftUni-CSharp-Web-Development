using System;

namespace _01.BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90);
            Console.WriteLine(book);

            GoldenEditionBook goldenBook = 
                new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.90);
            Console.WriteLine(goldenBook);
        }
    }
}
