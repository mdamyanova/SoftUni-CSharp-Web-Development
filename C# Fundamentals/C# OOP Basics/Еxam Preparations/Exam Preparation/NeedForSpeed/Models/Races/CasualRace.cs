namespace NeedForSpeed.Models.Races
{
    public class CasualRace : Race
    {
        public CasualRace(int length, string route, int prizePool) : 
            base(length, route, prizePool)
        {
        }

        protected override void CalculatePoints()
        {
            foreach (var c in this.Cars)
            {
                c.CarPoints = (c.Horsepower / c.Acceleration) + (c.Suspension + c.Durability);
            }
        }
    }
}