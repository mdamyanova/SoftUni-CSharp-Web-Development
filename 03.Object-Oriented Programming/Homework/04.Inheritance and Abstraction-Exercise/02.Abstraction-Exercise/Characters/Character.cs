using _02.Abstraction_Exercise.Interfaces;

namespace _02.Abstraction_Exercise.Characters
{
    public abstract class Character : IAttack
    {
        protected Character(int health, int mana, int damage)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
        }

        public int Health { get; set; }
        
        public int Mana { get; set; }

        public int Damage { get; set; }

        public abstract void Attack(Character character);
    }
}