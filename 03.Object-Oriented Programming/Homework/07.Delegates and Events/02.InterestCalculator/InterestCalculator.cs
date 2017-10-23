using System;

namespace _02.InterestCalculator
{
    public class InterestCalculator
    {
        public delegate double CalculateInterest(decimal money, double interest, int years);
       
        private decimal money;
        private double interest;
        private int years;
        private readonly CalculateInterest myDelegate;

        public InterestCalculator(decimal money, double interest, int years, CalculateInterest myDelegate)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;      
            this.myDelegate = myDelegate;
        }

        public decimal Money
        {
            get { return this.money; }
            private set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public double Interest
        {
            get { return this.interest; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest cannot be negative");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            private set
            {
                if (value < 0)
                {
                  throw new ArgumentOutOfRangeException("Years cannot be negative");
                }
                this.years = value;
            }
        }
     
        public override string ToString()
        {
            return $"{this.myDelegate(this.Money, this.Interest, this.Years):F4}";
        }
    }
}