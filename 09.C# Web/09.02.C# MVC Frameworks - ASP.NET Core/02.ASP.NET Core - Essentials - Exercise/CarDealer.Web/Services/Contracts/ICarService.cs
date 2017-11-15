namespace CarDealer.Web.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Cars;

    public interface ICarService
    {
        IEnumerable<CarModel> AllCars();
        IEnumerable<CarModel> CarsFromMake(string make);
        CarWithPartsModel CarWithParts(int id);
    }
}