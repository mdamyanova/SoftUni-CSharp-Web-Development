namespace CarDealer.Web.Services.Models.Collections
{
    using System.Collections.Generic;

    public class ListingCustomersModel
    {
        public ICollection<CustomerModel> Customers{ get; set; } = new List<CustomerModel>();
    }
}