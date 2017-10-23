using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class CustomComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.CompareTo(y.Name);

            if (result == 0)
            {
                result = x.Age.CompareTo(y.Age);
            }

            return result;
        }
    }
}