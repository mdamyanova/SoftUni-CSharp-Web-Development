namespace NeedForSpeed.Models.Races
{
    public class DragRace : Race
    {
        public DragRace(int length, string route, int prizePool) : 
            base(length, route, prizePool)
        {
        }

        protected override void CalculatePoints()
        {
            foreach (var c in this.Cars)
            {
                c.CarPoints = (c.Horsepower / c.Acceleration);
            }
        }
    }
}