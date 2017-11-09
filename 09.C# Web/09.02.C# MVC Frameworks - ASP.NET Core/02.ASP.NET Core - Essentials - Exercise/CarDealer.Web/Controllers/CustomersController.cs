namespace CarDealer.Web.Controllers
{
    using Services.Contracts;
    using Services.Models.Customers;
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
            var model = customers.TotalSalesById(int.Parse(id));
            return this.View(model);
        }

        [HttpGet("customers/create")]
        public IActionResult Create() => this.View();

        [HttpPost("customers/create")]
        public IActionResult Create(CustomerFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.customers.Create(model.Name, model.BirthDate, model.IsYoungDriver);
            return this.RedirectToAction(nameof(this.All), new {order = OrderType.Ascending.ToString()});
        }

        [HttpGet("customers/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);

            if (customer == null)
            {
                return this.NotFound();
            }

            return this.View(new CustomerFormModel
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [HttpPost("customers/edit/{id}")]
        public IActionResult Edit(int id, CustomerFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var customerExists = this.customers.Exists(id);

            if (!customerExists)
            {
                return this.NotFound();
            }

            this.customers.Edit(id, model.Name, model.BirthDate, model.IsYoungDriver);
            return this.RedirectToAction(nameof(this.All), new { order = OrderType.Ascending.ToString() });
        }
    }
}