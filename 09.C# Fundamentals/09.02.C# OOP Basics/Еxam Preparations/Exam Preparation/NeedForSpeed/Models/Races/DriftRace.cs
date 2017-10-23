namespace NeedForSpeed.Models.Races
{
    public class DriftRace : Race
    {
        public DriftRace(int length, string route, int prizePool) : 
            base(length, route, prizePool)
        {
        }
        protected override void CalculatePoints()
        {
            foreach (var c in this.Cars)
            {
                c.CarPoints = (c.Suspension + c.Durability);
            }
        }
    }
}