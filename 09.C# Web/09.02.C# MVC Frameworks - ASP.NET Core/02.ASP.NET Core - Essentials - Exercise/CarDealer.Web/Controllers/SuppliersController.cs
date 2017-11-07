namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Data;
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
            return null;
        }
    }
}