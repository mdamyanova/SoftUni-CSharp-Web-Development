namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [HttpGet("/Sales")]
        public IActionResult All()
        {
            var model = this.sales.Sales();
            return this.View(model);
        }

        [HttpGet("/Sales/{id}")]
        public IActionResult Details(string id)
        {
            var model = this.sales.Sale(int.Parse(id));
            return this.View(model);
        }

        [HttpGet("/Sales/discounted")]
        public IActionResult Discounted()
        {
            var model = this.sales.DiscountedSales();
            return this.View("All", model);
        }

        [HttpGet("/Sales/discounted/{percent}")]
        public IActionResult Percent(string percent)
        {
            var model = this.sales.DiscountedSalesWithPercent(double.Parse(percent));
            return this.View("All", model);
        }
    }
}