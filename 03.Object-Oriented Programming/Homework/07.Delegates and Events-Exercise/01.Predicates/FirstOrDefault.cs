using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Predicates
{
    public static class FirstOrDefault
    {
        public static T FirstOrDeafult<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            var matches = collection.Where(element => condition(element)).ToList();

            return matches.Count > 0 ? matches[0] : default(T);
        }
    }
}