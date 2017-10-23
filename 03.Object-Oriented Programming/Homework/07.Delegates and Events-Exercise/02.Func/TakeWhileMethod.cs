using System;
using System.Collections.Generic;

namespace _02.Func
{
    public static class TakeWhileMethod
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var matches = new List<T>();
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    matches.Add(element);
                }
                else
                {
                    return matches;
                }              
            }
            return matches;
        }
    }
}