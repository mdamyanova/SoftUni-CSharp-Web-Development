namespace CarDealer.App.Controllers
{
    using CarDealer.App.Helpers;
    using CarDealer.Data;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private CarDealerDbContext db;

        public SuppliersController(CarDealerDbContext db)
        {
            this.db = db;
        }

        [HttpGet("suppliers/{type}")]
        public IActionResult All(string type)
        {
            if (type == "local" || type == "importers")
            {
                var model = CarDealerDbQueries.GetFilterSuppliers(this.db, type);

                return this.View(model);
            }

            return this.NotFound();
        }
    }
}