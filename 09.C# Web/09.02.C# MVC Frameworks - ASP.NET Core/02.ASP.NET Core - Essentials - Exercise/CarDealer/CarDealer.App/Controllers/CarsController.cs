﻿namespace CarDealer.App.Controllers
{
    using Helpers;
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private CarDealerDbContext db;

        public CarsController(CarDealerDbContext db)
        {
            this.db = db;
        }

        [HttpGet("/cars/{make}")]
        public IActionResult All(string make)
        {
            var model = CarDealerDbQueries.GetCarsFromMake(this.db, make);
            return this.View(model);
        }

        [HttpGet("/cars/{id}/parts")]
        public IActionResult Parts(string id)
        {
            var model = CarDealerDbQueries.GetCarsWithPartsById(this.db, int.Parse(id));

            return this.View(model);
        }
    }
}