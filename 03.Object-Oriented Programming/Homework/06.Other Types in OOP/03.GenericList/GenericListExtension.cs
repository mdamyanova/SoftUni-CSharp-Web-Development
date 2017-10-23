using System;

namespace _03.GenericList
{
    public class GenericListExtension
    {
        public static T Min<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
            {
                return first;
            }         
                return second;
        }

        public static T Max<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            return second;
        }
    }
}