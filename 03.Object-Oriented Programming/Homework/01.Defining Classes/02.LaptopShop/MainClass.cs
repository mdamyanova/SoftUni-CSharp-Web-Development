using System;

namespace _02.LaptopShop
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            LaptopShop laptop = new LaptopShop(
            "Lenovo Yoga 2 Pro",
            "Lenovo",
            "Intel Core i5-4210U",
            8,
            "Intel HD Graphics 4400",
            128,
            "13.3\"(33.78 cm) - 3200 x 1800 (QHD)",
            new Battery(4, 2550, "LiIon"),
            4.5,
            2259);

            LaptopShop laptop2 = new LaptopShop(
            "Lenovo Youga 2 Pro",
              2259);

           Console.WriteLine(laptop);
           Console.WriteLine(laptop2);
        }
    }
}