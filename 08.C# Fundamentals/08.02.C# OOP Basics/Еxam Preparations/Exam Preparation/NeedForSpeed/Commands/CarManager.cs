using System.Collections.Generic;
using System.Linq;
using NeedForSpeed.Models;
using NeedForSpeed.Models.Cars;
using NeedForSpeed.Models.Races;

namespace NeedForSpeed.Commands
{
    public class CarManager
    {
        private Dictionary<int, Car> cars = new Dictionary<int, Car>();
        private Dictionary<int, Race> races = new Dictionary<int, Race>();
        private Garage garage = new Garage();

        public void Register(int id, string type, string brand, string model, int yearOfProduction,
            int horsepower, int acceleration, int suspension, int durability)
        {
            Car car;

            if (type == "Show")
            {
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }
            else
            { 
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            }

            cars.Add(id, car);
        }

        public string Check(int id)
        {
            var car = cars[id];

            return car.ToString();
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            Race race;

            if (type == "Casual")
            {
                race = new CasualRace(length, route, prizePool);
            }
            else if (type == "Drag")
            {
                race = new DragRace(length, route, prizePool);
            }
            else
            {
                race = new DriftRace(length, route, prizePool);
            }

            races.Add(id, race);
        }

        public void Participate(int carId, int raceId)
        {
            if (garage.Cars.Contains(cars[carId]))
            {
                return;
            }

            races[raceId].Cars.Add(cars[carId]);
        }

        public string Start(int id)
        {
            if (races[id].Cars.Count == 0)
            {           
                return "Cannot start the race with zero participants.";
            }
           
            var race = races[id];
            races.Remove(id);
            return race.ToString();
        }

        public void Park(int id)
        {
            if (races.Any(race => race.Value.Cars.Contains(cars[id])))
            {
                return;
            }

            garage.Cars.Add(cars[id]);
        }

        public void Unpark(int id)
        {
            garage.Cars.Remove(cars[id]);
        }

        public void Tune(int tuneIndex, string addOn)
        {
            if (!garage.Cars.Any()) return;

            foreach (var parkedCar in garage.Cars)
            {
                parkedCar.TuneUp(tuneIndex, addOn);
            }
        }
    }
}