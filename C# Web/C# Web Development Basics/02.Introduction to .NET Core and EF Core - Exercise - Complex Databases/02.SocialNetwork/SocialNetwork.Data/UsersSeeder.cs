namespace SocialNetwork.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialNetwork.Models;

    public class UsersSeeder
    {
        private static readonly Random random = new Random();

        public static void SeedUsers(SocialNetworkDbContext db)
        {
            const int totalUsers = 50;
            var biggestUserId = db
                                    .Users
                                    .OrderByDescending(u => u.Id)
                                    .Select(u => u.Id)
                                    .FirstOrDefault() + 1;
            var allUsers = new List<User>();

            for (int i = biggestUserId; i < biggestUserId + totalUsers; i++)
            {
                var user = new User
                {
                    Username = $"Username {i}",
                    Password = "Passw0rd#$",
                    Email = $"email{i}@email.com",
                    RegisteredOn = DateTime.Now.AddDays(-(100 + i * 10)),
                    LastTimeLoggedIn = DateTime.Now.AddDays(-i),
                    Age = i
                };

                allUsers.Add(user);
                db.Users.Add(user);
            }

            db.SaveChanges();

            var userIds = allUsers.Select(u => u.Id).ToList();

            for (int i = 0; i < userIds.Count; i++)
            {
                var currentUserId = userIds[i];

                var totalFriends = random.Next(5, 11);

                for (int j = 0; j < totalFriends; j++)
                {
                    var friendId = userIds[random.Next(0, userIds.Count)];
                    bool validFriendship = friendId != currentUserId;

                    var friendshipExists =
                        db.Friendships.Any(f => (f.FromUserId == currentUserId && f.ToUserId == friendId) ||
                                                (f.FromUserId == friendId && f.ToUserId == currentUserId));

                    if (friendshipExists)
                    {
                        validFriendship = false;
                    }

                    if (!validFriendship)
                    {
                        j--;
                        continue;
                    }

                    db.Friendships.Add(new Friendship
                    {
                        FromUserId = currentUserId,
                        ToUserId = friendId
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}