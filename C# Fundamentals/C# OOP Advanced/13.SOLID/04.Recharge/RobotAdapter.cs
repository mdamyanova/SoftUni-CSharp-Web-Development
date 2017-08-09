namespace _04.Recharge
{
    public class RobotAdapter : Robot, IRechargeable
    {
        public RobotAdapter(string id, int capacity) : base(id, capacity)
        {
        }

        public void Recharge()
        {
            this.CurrentPower = this.Capacity;
        }
    }
}