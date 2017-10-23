namespace _04.Recharge
{
    public abstract class Worker : ISleeper
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }

        public virtual void Sleep()
        {
            
        }
    }
}