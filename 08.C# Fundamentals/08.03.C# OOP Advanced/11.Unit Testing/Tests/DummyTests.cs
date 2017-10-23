using System;
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        private const int deadDummyHealth = 0;
        private const int dummyHealth = 10;
        private const int dummyExperience = 10;
        private const int dummyTakeAttack = 5;

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            //Arrange 
            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            dummy.TakeAttack(dummyTakeAttack);

            //Assert
            Assert.IsTrue(dummy.Health == dummyHealth - 5);
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            //Arrange 
            var dummy = new Dummy(deadDummyHealth, dummyExperience);

            //Act
            var exception = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(dummyTakeAttack));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arrange 
            var dummy = new Dummy(deadDummyHealth, dummyExperience);

            //Act
            var experience = dummy.GiveExperience();

            //Assert
            Assert.IsTrue(experience == dummyExperience);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            //Arrange
            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            var exception = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
         
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Target is not dead."));
        }
    }
}