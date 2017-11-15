namespace CarDealer.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [HttpGet("/cars/all")]
        public IActionResult All()
        {
            var model = this.cars.AllCars();
            return this.View(model);
        }

        [HttpGet("/cars/{make}")]
        public IActionResult All(string make)
        {
            var model = this.cars.CarsFromMake(make);
            return this.View(model);
        }

        [HttpGet("/cars/{id}/parts")]
        public IActionResult Parts(string id)
        {
            var model = this.cars.CarWithParts(int.Parse(id));
            return this.View(model);
        }
    }
}