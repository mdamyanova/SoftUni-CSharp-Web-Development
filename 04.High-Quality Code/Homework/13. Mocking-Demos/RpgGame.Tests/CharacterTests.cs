namespace RpgGame.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void Character_Should_Drop_First_Item()
        {
            // Arrange
            var possibleItemDrops = new List<Item>
                                        {
                                            new Item("Axe", 25, 5),
                                            new Item("Shield", 5, 50),
                                            new Item("Resilience Potion", 0, 30)
                                        };

            // Act
            var mock = new Mock<IRandomNumberProvider>();

            //another way -> 
            //var mock = new Mock<Random>();
            //mock.Setup(r => r.Next()).Returns(0);
            // for (int i = 0; i < 1000; i++)
            // {
            //     var num = mock.Object.Next(0);
            //      Assert.AreEqual(0, num);
            //  }
            mock.Setup(r => r.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            var character = new Character(possibleItemDrops, mock.Object);

            // Assert
            for (int i = 0; i < 1000; i++)
            {
                var item = character.DropItem();
                Assert.AreEqual("Axe", item.Name);
            }
        }
    }
}