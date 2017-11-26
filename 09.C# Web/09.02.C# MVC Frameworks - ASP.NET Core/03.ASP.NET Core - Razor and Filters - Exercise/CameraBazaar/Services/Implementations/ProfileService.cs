namespace CameraBazaar.Services.Implementations
{
    using Data;
    using Models.Cameras;
    using Models.Profile;
    using Contracts;
    using System.Linq;

    public class ProfileService : IProfileService
    {
        private readonly CameraBazaarDbContext db;

        public ProfileService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void ChangeEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePhone(string phone)
        {
            throw new System.NotImplementedException();
        }

        public ProfileViewModel Show()
        {
            var profile = this.db
                .Users
                .Select(u => new ProfileViewModel
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Cameras = u
                            .Cameras
                            .Select(c => new CameraListingViewModel
                            {
                                ImageUrl = c.ImageUrl,
                                Make = c.Make,
                                Model = c.Model,
                                Price = c.Price
                            })
                })
                .FirstOrDefault();

            return profile;
        }
    }
}