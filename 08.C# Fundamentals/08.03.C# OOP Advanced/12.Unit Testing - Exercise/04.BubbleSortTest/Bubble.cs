namespace _04.BubbleSortTest
{
    using System;

    public class Bubble
    {
        public void BubbleSort<T>(T[] items) where T : IComparable
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int minValue = i;

                for (int sort = i + 1; sort < items.Length; sort++)
                {
                    if (items[minValue].CompareTo(items[sort]) > 0)
                    {
                        minValue = sort;
                    }
                }

                T temp = items[i];
                items[i] = items[minValue];
                items[minValue] = temp;
            }
        }
    }
}