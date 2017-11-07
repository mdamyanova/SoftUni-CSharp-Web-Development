namespace CarDealer.Web.Services.Models.Collections
{
    using System.Collections.Generic;
 
    public class ListingCarsModel
    {
        public ICollection<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}