namespace _01.CustomStackTests
{
    using System;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _01.CustomStack;

    [TestClass]
    public class CustomStackTests
    {
        private CustomStack<int> stack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.stack = new CustomStack<int>();
        }

        [TestMethod]
        public void Push_EmptyStack_ShouldIncrementCount()
        {
            //Act
            this.stack.Push(5);

            //Assert
            Assert.AreEqual(1, this.stack.Count);
        }

        [TestMethod]
        public void Push_FullStack_ShouldResizeCorrectly()
        {
            //Arrange
            //this.stack.Capacity = 1;

            //Act
            for (int i = 0; i < 10; i++)
            {
                this.stack.Push(i);
            }

            //Assert
            Assert.AreEqual(10, this.stack.Count, "Stack count not correct");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrow()
        {            
            this.stack.Pop();
        }

        [TestMethod]
        public void Pop_ItemsInStack_ShouldReturnLastPushedItem_ByReference()
        {
            var items = new CustomStack<StringBuilder>();
            var stringBuilder1 = new StringBuilder("Text");
            var stringBuilder2 = new StringBuilder("Another text");

            items.Push(stringBuilder1);
            items.Push(stringBuilder2);

            var builder = items.Pop();

            Assert.AreSame(stringBuilder2, builder);
        }

        [TestMethod]
        public void Pop_NonEmptyStack_ShouldDecrementCount()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Push(3);

            Assert.AreEqual(3, this.stack.Count);
            this.stack.Pop();
            Assert.AreEqual(2, this.stack.Count);
        }
    }
}