using System.Collections.Generic;

namespace NeedForSpeed.Models
{
    public class Garage
    {
        //private ICollection<Car> cars;

        public Garage()
        {
            this.Cars = new List<Car>();
        }

        public ICollection<Car> Cars { get; protected set; }
    }
}