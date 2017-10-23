using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CustomLINQExtensionMethods
{
    public static class Methods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(element => !predicate(element)).ToList();
        }
        
        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection,
            Func<TSource, TSelector> function)
            where TSelector : IComparable<TSelector>

        {
            var result = collection.Select(function).ToList();

            var max = result[0];
            for (var i = 1; i < result.Count; i++)
            {
                if (result[i].CompareTo(max) > 0)
                {
                    max = result[i];
                }
            }
            return max;
        }
    }
}