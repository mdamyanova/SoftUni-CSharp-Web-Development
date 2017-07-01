using System.Collections.Generic;

namespace _08.RawData
{
    public class Car
    {
        public Car(string model, int engSpeed, int engPower, int cargoWeight, string cargoType,
            double tyre1PS, int tyre1Age, double tyre2PS, int tyre2Age, double tyre3PS, int tyre3Age, double tyre4PS, int tyre4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engSpeed, engPower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tyres = new List<Tyre>();

            Tyre firstTyre = new Tyre(tyre1PS, tyre1Age);
            Tyres.Add(firstTyre);
            Tyre secondTyre = new Tyre(tyre2PS, tyre2Age);
            Tyres.Add(secondTyre);
            Tyre thirdTyre = new Tyre(tyre3PS, tyre3Age);
            Tyres.Add(thirdTyre);
            Tyre fourthTyre = new Tyre(tyre4PS, tyre4Age);
            Tyres.Add(fourthTyre);
        }

        public Cargo Cargo { get; set; }

        public List<Tyre> Tyres { get; set; }

        public string Model { get; set; }

        public Engine Engine { get; set; }
    }
}