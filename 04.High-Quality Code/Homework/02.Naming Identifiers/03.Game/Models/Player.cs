namespace _03.Game.Models
{
    using System;

    public class Player
    {
        private string name;

        private int points;

        public Player()
        {
        }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the player cannot be null");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Points of the player cannot be negative");
                }

                this.points = value;
            }
        }
    }
}