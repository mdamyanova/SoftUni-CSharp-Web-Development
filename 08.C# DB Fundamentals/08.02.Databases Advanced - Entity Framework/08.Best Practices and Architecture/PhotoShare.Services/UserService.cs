namespace PhotoShare.Services
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService
    {

        public void RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool HasUser(string username, string password)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.
                    Any(u => u.Username == username && u.Password == password);

            }
        }

        public List<string> GetUserFriends(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username).Friends.Select(f => f.Username).ToList();
            }
        }

        public bool IsDeleted(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var isDeleted = context.Users.SingleOrDefault(u => u.Username == username).IsDeleted.Value;
                return isDeleted == true;
            }
        }

        public bool IsOwnerForAlbum(int userId, int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.AlbumRoles
                    .Any(albr => albr.Album.Id == albumId && albr.Role == 0 && albr.User.Id == userId);
            }
        }

        public bool AreFriends(string username, string username2)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username).Friends
                            .Any(u => u.Username == username2);
            }
        }

        public void MakeFriends(string username, string username2)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username);
                User user2 = context.Users.SingleOrDefault(u => u.Username == username2);

                user.Friends.Add(user2);
                user2.Friends.Add(user);

                context.SaveChanges();

            }
        }

        public void DeleteUser(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                user.IsDeleted = true;

                context.SaveChanges();
            }

        }

        public bool IsUsernameExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username.Equals(username));
            }
        }

        public User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username.Equals(username));
            }
        }

        public void UpdateUser(User updatedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User userToUpdate = context.Users
                    .Include("BornTown").Include("CurrentTown")
                    .SingleOrDefault(u => u.Id == updatedUser.Id);
                if (userToUpdate != null)
                {
                    if (updatedUser.Password != userToUpdate.Password)
                    {
                        userToUpdate.Password = updatedUser.Password;
                    }
                    if (updatedUser.CurrentTown != null
                        &&
                        (userToUpdate.CurrentTown == null ||
                        userToUpdate.CurrentTown.Id != updatedUser.CurrentTown.Id))
                    {
                        userToUpdate.CurrentTown = context.Towns.Find(updatedUser.CurrentTown.Id);
                    }
                    if (updatedUser.BornTown != null
                        &&
                        (userToUpdate.BornTown == null ||
                        userToUpdate.BornTown.Id != updatedUser.BornTown.Id))
                    {
                        userToUpdate.BornTown = context.Towns.Find(updatedUser.BornTown.Id);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
