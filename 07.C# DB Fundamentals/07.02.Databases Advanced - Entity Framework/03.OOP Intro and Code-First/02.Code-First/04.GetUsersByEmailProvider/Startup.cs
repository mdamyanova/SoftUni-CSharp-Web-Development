using System;
using System.Linq;
using _02.CreateUser;

namespace _04.GetUsersByEmailProvider
{
    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var context = new UsersContext();
            var result = context.UsersTable.Where(x => x.Email.EndsWith(input));
            foreach (var user in result)
            {
                Console.WriteLine($"{user.Username} {user.Email}");
            }
        }
    }
}