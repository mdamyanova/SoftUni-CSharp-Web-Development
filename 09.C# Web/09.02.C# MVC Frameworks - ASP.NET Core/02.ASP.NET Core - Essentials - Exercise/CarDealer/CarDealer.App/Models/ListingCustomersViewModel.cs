namespace CarDealer.App.Models
{
    using System.Collections.Generic;

    public class ListingCustomersViewModel
    {
        public ICollection<CustomersViewModel> Customers{ get; set; } = new List<CustomersViewModel>();
    }
}