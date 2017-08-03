using System;
using System.Linq;
using System.Reflection;
using _03._04._05.BarrackWars.Contracts;

namespace _03._04._05.BarrackWars.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == unitType);
            return (IUnit)Activator.CreateInstance(currentType);
        }
    }
}