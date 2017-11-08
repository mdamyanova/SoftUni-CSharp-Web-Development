﻿namespace CarDealer.Web.Services.Contracts
{
    using CarDealer.Web.Services.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> CarsFromMake(string make);
        CarWithPartsModel CarWithParts(int id);
    }
}