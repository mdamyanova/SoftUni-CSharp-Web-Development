using System;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}