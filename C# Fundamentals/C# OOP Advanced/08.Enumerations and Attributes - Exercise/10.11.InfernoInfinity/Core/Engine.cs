using System;
using System.Linq;
using _10._11.InfernoInfinity.Attributes;
using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Core
{
    public class Engine
    {
        private readonly Controller.Controller controller;

        public Engine()
        {
            this.controller = new Controller.Controller();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(';');
                CommandInterpreter(commandArgs);
            }
        }

        private void CommandInterpreter(string[] commandArgs)
        {
            var command = commandArgs[0];
            var weaponName = string.Empty;
            var socketIndex = 0;
            var attributes = typeof(Weapon).GetCustomAttributes(false);
            var typeAttribute = attributes.ToArray()[0] as MyClassAttribute;

            switch (command.ToLower())
            {
                case "create":
                    var weaponInfo = commandArgs[1];
                    weaponName = commandArgs[2];
                    this.controller.CreateWeapon(weaponInfo, weaponName);
                    break;
                case "add":
                    weaponName = commandArgs[1];
                    socketIndex = int.Parse(commandArgs[2]);
                    var gemInfo = commandArgs[3];
                    this.controller.Add(weaponName, socketIndex, gemInfo);
                    break;
                case "remove":
                    weaponName = commandArgs[1];
                    socketIndex = int.Parse(commandArgs[2]);
                    this.controller.Remove(weaponName, socketIndex);
                    break;
                case "print":
                    weaponName = commandArgs[1];
                    this.controller.Print(weaponName);
                    break;
                case "author":
                    Console.WriteLine($"Author: {typeAttribute.Author}");
                    break;
                case "revision":
                    Console.WriteLine($"Revision: {typeAttribute.Revision}");
                    break;
                case "description":
                    Console.WriteLine($"Class description: {typeAttribute.Description}");
                    break;
                case "reviewers":
                    Console.WriteLine($"Reviewers: {typeAttribute.Reviewers}");
                    break;
            }
        }
    }
}