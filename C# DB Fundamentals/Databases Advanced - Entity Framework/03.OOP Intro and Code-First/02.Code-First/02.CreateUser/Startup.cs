using System;
using _02.CreateUser.Models;

namespace _02.CreateUser
{
    class Startup
    {
        static void Main(string[] args)
        {
            var pesho = new User()
            {
                Username = "pe6o",
                Password = "pe6oO!",
                Email = "pe6kata@abv.bg",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                Age = 66,
                IsDeleted = false,
            };

            var mitko = new User()
            {
                Username = "mitache",
                Password = "Mitk0@",
                Email = "dimitar.lipov@gmail.com",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                Age = 32,
                IsDeleted = false
            };

            var trayana = new User()
            {
                Username = "trayanka9",
                Password = "Trayan1a!!!A",
                Email = "tr_tr@abv.bg",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                Age = 18,
                IsDeleted = false
            };

            var context = new UsersContext();
            context.UsersTable.Add(pesho);
            context.UsersTable.Add(mitko);
            context.UsersTable.Add(trayana);

            context.SaveChanges();
        }
    }
}