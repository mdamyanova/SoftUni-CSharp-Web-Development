using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    public class InfernoIII
    {
        public static void Main()
        {
            var filters = new Dictionary<string, Func<List<int>, List<int>>>();
            var collection = Console.ReadLine().Split().Select(int.Parse).ToList();
            var input = Console.ReadLine();

            while (input != "Forge")
            {
                var tokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var filterType = tokens[1];
                var condition = tokens[2];

                if (command == "Exclude")
                {
                    var nameOfFilter = filterType + condition;
                    Func<List<int>, List<int>> newFilter = null;

                    if (filterType == "Sum Left")
                    {
                        newFilter = GetSumLeftFilter(int.Parse(condition));
                    }
                    else if (filterType == "Sum Right")
                    {
                        newFilter = GetSumRightFilter(int.Parse(condition));
                    }
                    else if (filterType == "Sum Left Right")
                    {
                        newFilter = GetSumLeftRightFilter(int.Parse(condition));
                    }

                    if (newFilter != null && !filters.ContainsKey(nameOfFilter))
                    {
                        filters[nameOfFilter] = newFilter;
                    }
                }
                else if (command == "Reverse")
                {
                    string nameOfFilter = filterType + condition;

                    if (filters.ContainsKey(nameOfFilter))
                    {
                        filters.Remove(nameOfFilter);
                    }
                }

                input = Console.ReadLine();
            }

            var setOfIndexesToRemove = new SortedSet<int>();

            foreach (var filter in filters)
            {
                setOfIndexesToRemove.UnionWith(filter.Value.Invoke(collection));
            }

            var listOfIndexesToRemove = setOfIndexesToRemove.ToList();
            listOfIndexesToRemove.Reverse();

            foreach (var index in listOfIndexesToRemove)
            {
                collection.RemoveAt(index);
            }

            Console.WriteLine(string.Join(" ", collection));
        }

        public static Func<List<int>, List<int>> GetSumLeftFilter(int sum)
        {
            Func<List<int>, List<int>> newStartsFilter = (collection) =>
            {
                var indexesToRemove = new List<int>();
                var previous = 0;

                for (int i = 0; i < collection.Count; i++)
                {
                    if (collection[i] + previous == sum)
                    {
                        indexesToRemove.Add(i);
                    }

                    previous = collection[i];
                }

                return indexesToRemove;
            };

            return newStartsFilter;
        }

        public static Func<List<int>, List<int>> GetSumRightFilter(int sum)
        {
            Func<List<int>, List<int>> newStartsFilter = (List<int> collection) =>
            {
                var indexesToRemove = new List<int>();
                var previous = 0;

                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    if (collection[i] + previous == sum)
                    {
                        indexesToRemove.Add(i);
                    }

                    previous = collection[i];
                }

                return indexesToRemove;
            };

            return newStartsFilter;
        }

        public static Func<List<int>, List<int>> GetSumLeftRightFilter(int sum)
        {
            Func<List<int>, List<int>> newStartsFilter = (collection) =>
            {
                var indexesToRemove = new List<int>();
                var previous = 0;

                for (int i = 0; i < collection.Count; i++)
                {
                    var next = 0;

                    if (i + 1 < collection.Count)
                    {
                        next = collection[i + 1];
                    }
                    else
                    {
                        next = 0;
                    }

                    if (collection[i] + previous + next == sum)
                    {
                        indexesToRemove.Add(i);
                    }

                    previous = collection[i];
                }

                return indexesToRemove;
            };

            return newStartsFilter;
        }
    }
}