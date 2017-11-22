namespace CameraBazaar.Models.Cameras
{
    using Data.Models.Enums;

    public class CameraListingViewModel
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}