namespace CarDealer.App.Models.Collections
{
    using System.Collections.Generic;

    public class ListingSuppliersViewModel
    {
        public ICollection<SupplierViewModel> Suppliers { get; set; } = new List<SupplierViewModel>();
    }
}