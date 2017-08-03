using System;
using System.Linq;
using System.Reflection;
using _03._04._05.BarrackWars.Contracts;
using _03._04._05.BarrackWars.Core.Commands;

namespace _03._04._05.BarrackWars.Core
{
    public class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            var result = string.Empty;

            try
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => string.Equals(t.Name, commandName, StringComparison.CurrentCultureIgnoreCase));
                var command = (Command)Activator.CreateInstance(currentType, data, this.repository, this.unitFactory);
                result = command.Execute();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return result;
        }

        private string ReportCommand(string[] data)
        {
            string output = this.repository.Statistics;
            return output;
        }


        private string AddUnitCommand(string[] data)
        {
            string unitType = data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}