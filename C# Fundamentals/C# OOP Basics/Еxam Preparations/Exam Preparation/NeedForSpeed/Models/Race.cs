using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeedForSpeed.Models
{
    public abstract class Race
    {
        //private int length;
        //private string route;
        //private int prizePool;
        //private ICollection<Car> cars;

        protected Race(int length, string route, int prizePool)
        {
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.Cars = new List<Car>();
        }

        public int Length { get; protected set; }
        public string Route { get; protected set; }
        public int PrizePool { get; protected set; }
        public ICollection<Car> Cars { get; protected set; }

        protected virtual List<Car> PerformancePoints()
        {
            this.CalculatePoints();
            return this.Cars.OrderByDescending(x => x.CarPoints).Take(3).ToList();

        }

        private int GetPrize(int number)
        {
            switch (number)
            {
                case 1: return (this.PrizePool * 50) / 100;
                case 2: return (this.PrizePool * 30) / 100;
                case 3: return (this.PrizePool * 20) / 100;
                default: return 0;
            }
        }

        protected abstract void CalculatePoints();

        public override string ToString()
        {
            var winners = this.PerformancePoints();
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Route} - {this.Length}");

            int num = winners.Count < 3 ? winners.Count : 3;

            for (int i = 1; i <= num; i++)
            {
                var car = winners.Skip(i - 1).FirstOrDefault();
                sb.AppendLine($"{i}. {car.Brand} {car.Model} {car.CarPoints}PP - ${this.GetPrize(i)}");
            }

            return sb.ToString().Trim();
        }
    }
}