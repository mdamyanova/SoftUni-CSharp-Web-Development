using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _01.OOPIntro.Models
{
    class Family
    {
        public Family()
        {
          People = new List<Person>();
        }
        public static List<Person> People { get; set; }

        public void AddMember(Person member)
        {
           People.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestMember = People.OrderByDescending(a => a.Age).First();
            return oldestMember;
        }
    }
}
