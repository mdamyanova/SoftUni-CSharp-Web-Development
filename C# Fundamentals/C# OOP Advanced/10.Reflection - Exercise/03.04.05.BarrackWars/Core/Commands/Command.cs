using _03._04._05.BarrackWars.Contracts;

namespace _03._04._05.BarrackWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data
        {
            get => data;
            set => data = value;
        }

        public abstract string Execute();
    }
}