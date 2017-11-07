namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.Enums;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [HttpGet("customers/all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "ascending" ? OrderType.Ascending : OrderType.Descending;
            var model = customers.OrderedCustomers(orderDirection);

            return this.View(model);
        }

        [HttpGet("customers/{id}")]
        public IActionResult Sales(string id)
        {
            return null;
        }
    }
}
