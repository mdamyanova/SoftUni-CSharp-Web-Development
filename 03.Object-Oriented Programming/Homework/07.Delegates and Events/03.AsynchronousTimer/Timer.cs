using System;
using System.Threading;

namespace _03.AsynchronousTimer
{
    public class Timer
    {
        private int ticks;
        private int interval;
        private string message;

        public Timer(Action<string> action, int ticks, int interval, string message)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.Interval = interval;
            this.Message = message;
        }

        public int Ticks
        {
            get { return this.ticks; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Tikcs cannot be negative");
                }
                this.ticks = value;
            }
        }

        public int Interval
        {
            get { return this.interval; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interval cannot be negative");
                }
                this.interval = value;
            }
        }

        public string Message
        {
            get { return this.message; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Message cannot be empty");
                }
                this.message = value;
            }
        }

        public Action<string> Action { get; private set; }

        public void Run()
        {
            var parallel = new Thread(this.Execute);
            parallel.Start();
        }

        private void Execute()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.Interval);
                Console.WriteLine(this.Message);
            }
        }
    }
}