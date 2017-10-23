using System;

namespace _08.MostFrequentNumber
{
    using System.Linq;

    public class MostFrequentNumber
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
           
            int max = 0;
            int mostFrequentNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 0;
                int currNum = numbers[i];

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == currNum)
                    {
                        count++;               
                    }
                }

                if (count > max)
                {
                    max = count;
                    mostFrequentNumber = currNum;
                }
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}