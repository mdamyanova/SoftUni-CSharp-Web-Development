namespace CarDealer.Web.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private CarDealerDbContext db;

        public SalesController(CarDealerDbContext db)
        {
            this.db = db;
        }

        [HttpGet("/Sales")]
        public IActionResult All()
        {
           
            return this.View();
        }

        [HttpGet("/Sales/{id}")]
        public IActionResult Details(string id)
        {
            return null;
        }

        [HttpGet("/Sales/discounted")]
        public IActionResult AllDiscounted(string make)
        {
            return null;
        }

        [HttpGet("/Sales/discounted/{percent}")]
        public IActionResult AllDiscountedWithPercent(string make)
        {
            return null;
        }
    }
}