namespace CarDealer.App.Controllers
{
    using Helpers;
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        private CarDealerDbContext db;

        public CustomersController(CarDealerDbContext db)
        {
            this.db = db;
        }

        // nice :) 
        [HttpGet("customers/all/{order}")]
        public IActionResult All(string order)
        {
            if (order == "ascending" || order == "descending")
            {
                var model = CarDealerDbQueries.GetOrderedCustomers(this.db, order);
                return this.View(model);
            }

            return this.NotFound();

        }
    }
}