using System.Collections.Generic;

namespace CarDealer.Web.Services.Models
{
    public class CarWithPartsModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<PartModel> Parts { get; set; } = new List<PartModel>();
    }
}