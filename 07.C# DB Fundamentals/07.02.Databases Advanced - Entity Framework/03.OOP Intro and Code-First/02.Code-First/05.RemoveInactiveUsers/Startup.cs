using System;
using System.Linq;
using _02.CreateUser;

namespace _05.RemoveInactiveUsers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var date = Convert.ToDateTime(input);
            var context = new UsersContext();
            var usersAfterDate = context.UsersTable.Where(u => u.LastTimeLoggedIn < date);
            foreach (var user in usersAfterDate)
            {
                user.IsDeleted = true;
            }
            Console.WriteLine(!usersAfterDate.Any()
                ? "No users has been deleted"
                : $"{usersAfterDate.Count()} users has been deleted");
            foreach (var user in usersAfterDate)
            {
                context.UsersTable.Remove(user);
            }
        }
    }
}