namespace CarDealer.App.Models.Collections
{
    using System.Collections.Generic;

    public class ListingCustomersViewModel
    {
        public ICollection<CustomerViewModel> Customers{ get; set; } = new List<CustomerViewModel>();
    }
}