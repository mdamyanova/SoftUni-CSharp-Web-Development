using System;
using _10._11.InfernoInfinity.Attributes;
using _10._11.InfernoInfinity.Enums;
using _10._11.InfernoInfinity.Interfaces;

namespace _10._11.InfernoInfinity.Models
{
    [MyClass(author: "Pesho",
        revision: 3,
        description: "Used for C# OOP Advanced Course - Enumerations and Attributes.",
        reviewers: "Pesho, Svetlio")]

public abstract class Weapon : IWeapon
    {
        private int minDamage;
        private int maxDamage;
        private int strength;
        private int agility;
        private int vitality;
        private readonly Gem[] sockets;

        protected Weapon(string name, string quality, int numberOfSockets)
        {
            this.Name = name;

            this.Quality = Enum.Parse(typeof(WeaponQuality), quality);

            this.sockets = new Gem[numberOfSockets];
        }

        public string Name { get; private set; }

        public int MinDamage
        {
            get => this.minDamage + this.GemMinDamageBonus();
            set => this.minDamage = value * (int)this.Quality;
        }

        int IWeapon.MinDamage => this.MinDamage;

        public int MaxDamage
        {
            get => this.maxDamage + this.GemMaxDamageBonus();
            protected set => this.maxDamage = value * (int)this.Quality;
        }

        public object Quality { get; protected set; }

        public void AddSocket(int socketIndex, Gem gem)
        {
            this.sockets[socketIndex] = gem;
        }

        public void RemoveSocket(int socketIndex)
        {
            this.sockets[socketIndex] = null;
        }

        private void ApplyBonus()
        {
            this.strength = 0;
            this.agility = 0;
            this.vitality = 0;

            foreach (var gem in this.sockets)
            {
                if (gem != null)
                {
                    this.strength += gem.Strength;
                    this.agility += gem.Agility;
                    this.vitality += gem.Vitality;
                }
            }
        }

        private int GemMinDamageBonus()
        {
            return this.strength * 2 + this.agility * 1;
        }

        private int GemMaxDamageBonus()
        {
            return this.strength * 3 + this.agility * 4;
        }

        public override string ToString()
        {
            this.ApplyBonus();

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.strength} Strength, +{this.agility} Agility, +{this.vitality} Vitality";
        }
    }
}