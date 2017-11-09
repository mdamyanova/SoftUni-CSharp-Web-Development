namespace CarDealer.Web.Services.Contracts
{
    using System.Collections.Generic;  
    using Models.Sales;

    public interface ISaleService
    {
        IEnumerable<SaleModel> Sales();
        SaleDetailsModel Sale(int id);
        IEnumerable<SaleModel> DiscountedSales();
        IEnumerable<SaleModel> DiscountedSalesWithPercent(double percent);
    }
}