namespace _02.Abstraction_Exercise.Characters
{
    public class Warrior : Character
    {
        public Warrior() :
            base(300, 0, 120)
        {
            
        }

        public override void Attack(Character character)
        {
            this.Damage -= 100;
        }
    }
}