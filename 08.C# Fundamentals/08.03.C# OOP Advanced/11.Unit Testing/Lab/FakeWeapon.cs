using Lab.Interfaces;

namespace Lab
{
    public class FakeWeapon : IWeapon
    {
        public void Attack(ITarget target)
        {
            
        }

        public int AttackPoints => 10;
        public int DurabilityPoints => 10;
    }
}