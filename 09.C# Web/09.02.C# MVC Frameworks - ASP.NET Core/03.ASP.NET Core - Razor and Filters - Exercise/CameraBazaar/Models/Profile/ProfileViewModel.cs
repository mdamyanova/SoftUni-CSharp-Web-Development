namespace CameraBazaar.Models.Profile
{
    using Cameras;
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<CameraListingViewModel> Cameras { get; set; }
    }
}