using System;

namespace _04.BubbleSortTest
{
    class Program
    {
        static void Main()
        {
            var items = new []{1, 4, 3};
            var bubble = new Bubble();
            bubble.BubbleSort(items);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
