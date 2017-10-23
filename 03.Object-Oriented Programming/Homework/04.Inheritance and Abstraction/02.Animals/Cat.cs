using System;

namespace _02.Animals
{
    public class Cat : Animal, ISoundProducible
    {      
        public Cat(string name, int age, string gender) : 
            base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Myaaaauuuu");
        }
    }
}