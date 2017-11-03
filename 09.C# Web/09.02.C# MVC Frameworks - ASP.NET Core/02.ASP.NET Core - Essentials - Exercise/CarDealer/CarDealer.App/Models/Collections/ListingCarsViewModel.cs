namespace CarDealer.App.Models.Collections
{
    using System.Collections.Generic;

    public class ListingCarsViewModel
    {
        public ICollection<CarViewModel> Cars { get; set; } = new List<CarViewModel>();
    }
}