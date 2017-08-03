using System;
using _03._04._05.BarrackWars.Contracts;

namespace _03._04._05.BarrackWars.Core.Commands
{
    public class Fight : Command
    {

        [Inject] private IRepository repository;
        [Inject] private IUnitFactory unitFactory;

        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get => repository;
            set => repository = value;
        }

        public IUnitFactory UnitFactory
        {
            get => unitFactory;
            set => unitFactory = value;
        }
        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}