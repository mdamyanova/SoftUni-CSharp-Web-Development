using System;

namespace _02.BankOfKurtovoKonare
{
    public class Customer
    {
        private string name;

        private double money;

        public Customer(string name, double money, Entity entity)
        {
            this.Name = name;
            this.Money = money;
            this.Entity = entity;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of customer cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money of customer cannot be negative");
                }
                this.money = value;
            }
        }

        public Entity Entity { get; set; }
    }
}