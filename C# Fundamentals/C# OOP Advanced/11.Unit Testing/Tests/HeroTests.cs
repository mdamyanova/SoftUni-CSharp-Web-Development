using Lab.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class HeroTests
    {
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            //Arrange
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, fakeWeapon.Object);

            //Act
            hero.Attack(fakeTarget.Object);

            //Assert
            Assert.AreEqual(20, hero.Experience);
        }
    }
}