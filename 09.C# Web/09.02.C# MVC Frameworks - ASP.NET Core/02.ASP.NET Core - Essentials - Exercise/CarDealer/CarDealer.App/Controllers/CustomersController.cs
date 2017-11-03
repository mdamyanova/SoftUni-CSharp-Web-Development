namespace CarDealer.App.Controllers
{
    using CarDealer.App.Helpers;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        [HttpGet("customers/all/ascending")]
        public IActionResult All()
        {
            var model = CarDealerDbQueries.GetOrderedCustomers("ascending");
            return this.View(model);
        }
    }
}