using System;
using NUnit.Framework;

namespace _03.IteratorTest
{
    public class ListIteratorTests
    {
        private const int DefaultStartIndex = 0;
        private ListIterator listIterator;
        private int listIteratorCount;

        [SetUp]
        public void InitList()
        {
            this.listIterator = new ListIterator("Petko", "Dragan", "Petkan");
            this.listIteratorCount = this.listIterator.Data.Count;
        }

        //constructor tests

        [Test]
        public void CreateEmptyListIterator()
        {
            var emptyListIterator = new ListIterator();
            Assert.AreEqual(0, emptyListIterator.Data.Count);         
        }

        [Test]
        public void CreateListIteratorWithItems()
        {
            Assert.AreEqual(3, this.listIterator.Data.Count);
        }

        [Test]
        public void CheckValueOfIndexWhenInitListIterator()
        {
            Assert.AreEqual(DefaultStartIndex, this.listIterator.Index);
        }

        [Test]
        public void CreateListIteratorWithNullItems()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var iterator = new ListIterator(null);
            });

            Assert.AreEqual("Value cannot be null.\r\nParameter name: items", exception.Message);
        }

        //Move method tests

        [Test]
        public void MoveToNextIndex()
        {
            var result = this.listIterator.Move();
            Assert.IsTrue(result);
        }

        [Test]
        public void MoveToUnexistingIndex()
        {
            for (int i = 0; i < this.listIteratorCount; i++)
            {
                this.listIterator.Move();
            }

            var result = this.listIterator.Move();
            Assert.IsFalse(result);
        }

        //HasNext method tests 

        [Test]
        public void HasNextReturnsTrueWhenWorkProperly()
        {
            var result = this.listIterator.HasNext();
            Assert.IsTrue(result);
        }

        [Test]
        public void HasNextReturnsFalseWhenIndexIsInTheEnd()
        {
            for (int i = 0; i < this.listIteratorCount; i++)
            {
                this.listIterator.Move();
            }

            var result = this.listIterator.HasNext();
            Assert.IsFalse(result);
        }

        //Print method tests

        [Test]
        public void PrintFirstElement()
        {
            Assert.AreEqual("Petko", this.listIterator.Print());
        }

        [Test]
        public void PrintAllElements()
        {
            Assert.AreEqual("Petko", this.listIterator.Print());
            this.listIterator.Move();
            Assert.AreEqual("Dragan", this.listIterator.Print());
            this.listIterator.Move();
            Assert.AreEqual("Petkan", this.listIterator.Print());
        }

        [Test]
        public void PrintOnEmptyListIterator()
        {
            var fakeList = new ListIterator();
            var exception = Assert.Throws<InvalidOperationException>(() => fakeList.Print());
            Assert.AreEqual("Invalid Operation!", exception.Message);
        }
    }
}