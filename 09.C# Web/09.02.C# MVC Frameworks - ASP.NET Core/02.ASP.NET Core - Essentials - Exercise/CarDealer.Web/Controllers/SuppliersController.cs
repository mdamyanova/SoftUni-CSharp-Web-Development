namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Data;
    using CarDealer.Web.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        [HttpGet("suppliers/{type}")]
        public IActionResult All(string type)
        {
            var model = suppliers.FilterSuppliers(type);
            return this.View(model);
        }
    }
}