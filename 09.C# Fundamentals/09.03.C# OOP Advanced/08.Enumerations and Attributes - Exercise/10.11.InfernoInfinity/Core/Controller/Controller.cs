using System;
using System.Collections.Generic;
using System.Linq;
using _10._11.InfernoInfinity.Factories;
using _10._11.InfernoInfinity.Models;

namespace _10._11.InfernoInfinity.Core.Controller
{
    public class Controller
    {
        private readonly WeaponFactory weaponFactory;
        private readonly GemFactory gemFactory;
        private readonly List<Weapon> weapons;

        public Controller()
        {
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.weapons = new List<Weapon>();
        }

        public void CreateWeapon(string weaponInfo, string weaponName)
        {
            try
            {
                Weapon weapon = this.weaponFactory.Create(weaponInfo, weaponName);
                this.weapons.Add(weapon);
            }
            catch (ArgumentException)
            {
            }
        }

        public void Add(string weaponName, int socketIndex, string gemInfo)
        {
            var gem = this.gemFactory.Create(gemInfo);
            var weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

            try
            {
                weapon.AddSocket(socketIndex, gem);
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        public void Remove(string weaponName, int socketIndex)
        {
            var weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

            try
            {
                weapon.RemoveSocket(socketIndex);
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        public void Print(string weaponName)
        {
            try
            {
                var weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);
                Console.WriteLine(weapon);
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}