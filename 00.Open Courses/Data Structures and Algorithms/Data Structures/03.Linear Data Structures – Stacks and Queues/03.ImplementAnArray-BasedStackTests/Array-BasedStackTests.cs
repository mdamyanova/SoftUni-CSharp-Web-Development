using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03.ImplementAnArray_BasedStackTests
{
    using _03.ImplementAnArray_BasedStack;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FillEmptyStack_PushAndPopElements_AssertCount()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);

            stack.Push(198);
            Assert.AreEqual(1, stack.Count);

            var element = stack.Pop();
            Assert.AreEqual(198, element);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void StackOfStrings_PushAndPop_AssertCount()
        {
            var stack = new ArrayStack<string>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0; i < 1000; i++)
            {
                var expectedCount = i + 1;
                stack.Push("penka");

                Assert.AreEqual(expectedCount, stack.Count);
            }

            for (int i = 1000 - 1; i >= 0; i--)
            {
                var expectedCount = i;
                var element = stack.Pop();
                Assert.AreEqual("penka", element);
                Assert.AreEqual(expectedCount, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStack_PopElement_ShouldThrow()
        {
            var stack = new ArrayStack<int>();

            stack.Pop();
        }

        [TestMethod]
        public void FillStackWithInitialCapacity_PushAndPopElements_AssertCount()
        {
            var stack = new ArrayStack<int>(1);

            Assert.AreEqual(0, stack.Count);

            stack.Push(3);
            Assert.AreEqual(1, stack.Count);

            stack.Push(5);
            Assert.AreEqual(2, stack.Count);

            var element = stack.Pop();
            Assert.AreEqual(5, element);
            Assert.AreEqual(1, stack.Count);

            var element1 = stack.Pop();
            Assert.AreEqual(3, element1);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void SeveralItemsArrayStack_ToArray_ShouldReturnItemsInReversedOrder()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);

            var array = stack.ToArray();
            var expected = new int[] { 7, -2, 5, 3 };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void StackWithDates_ToArray_ShouldReturnEmptyArray()
        {
            var stack = new ArrayStack<DateTime>();

            var array = stack.ToArray();
            var expected = new int[0];

            CollectionAssert.AreEqual(expected, array);
        }
    }
}