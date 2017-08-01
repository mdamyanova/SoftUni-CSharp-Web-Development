using System;
using _10._11.InfernoInfinity.Enums;
using _10._11.InfernoInfinity.Interfaces;

namespace _10._11.InfernoInfinity.Models
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;

        protected Gem(string quality)
        {
            this.Quality = Enum.Parse(typeof(GemQuality), quality);
        }

        public object Quality { get; private set; }

        public int Vitality
        {
            get => this.vitality;
            protected set => this.vitality = value + (int)this.Quality;
        }

        public int Agility
        {
            get => this.agility;
            protected set => this.agility = value + (int)this.Quality;
        }

        public int Strength
        {
            get => this.strength;
            protected set => this.strength = value + (int)this.Quality;
        }
    }
}