using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SecondNature
{
    public class SecondNature
    {
        public static void Main()
        {
            var flowers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var buckets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondNature = new Queue<int>();

            var indexBucket = buckets.Length - 1;
            var indexFlower = 0;

            while (indexBucket >= 0 && indexFlower < flowers.Length)
            {
                if (buckets[indexBucket] == flowers[indexFlower])
                {
                    secondNature.Enqueue(flowers[indexFlower]);

                    buckets[indexBucket] = 0;
                    indexBucket--;
                    indexFlower++;
                }
                else if (buckets[indexBucket] < flowers[indexFlower])
                {
                    flowers[indexFlower] -= buckets[indexBucket];
                    buckets[indexBucket] = 0;
                    indexBucket--;
                }
                else
                {
                    buckets[indexBucket] -= flowers[indexFlower];
                    flowers[indexFlower] = 0;

                    if (indexBucket != 0)
                    {
                        buckets[indexBucket - 1] += buckets[indexBucket];
                        buckets[indexBucket] = 0;
                        indexBucket--;
                    }

                    indexFlower++;
                }
            }

            var result = new StringBuilder();

            if (buckets[0] != 0)
            {
                for (int i = indexBucket; i >= 0; i--)
                {
                    result.Append(buckets[i] + " ");
                }
            }
            else
            {
                for (int i = indexFlower; i < flowers.Length; i++)
                {
                    result.Append(flowers[i] + " ");
                }
            }

            result.AppendLine();

            if (secondNature.Any())
            {
                while (secondNature.Any())
                {
                    result.Append(secondNature.Dequeue() + " ");
                }
            }
            else
            {
                result.Append("None");
            }


            Console.WriteLine(result);
        }
    }
}