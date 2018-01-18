using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07.LinkedQueueTests
{
    using _07.LinkedQueue;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void FillEmptyQueue_EnqueueAndDequeueElements_AssertCount()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(198);
            Assert.AreEqual(1, queue.Count);

            var element = queue.Dequeue();
            Assert.AreEqual(198, element);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void QueueOfStrings_EnqueueAndDequeue_AssertCount()
        {
            var queue = new LinkedQueue<string>();
            Assert.AreEqual(0, queue.Count);

            for (int i = 0; i < 1000; i++)
            {
                var expectedCount = i + 1;
                queue.Enqueue("penka");

                Assert.AreEqual(expectedCount, queue.Count);
            }

            for (int i = 1000 - 1; i >= 0; i--)
            {
                var expectedCount = i;
                var element = queue.Dequeue();
                Assert.AreEqual("penka", element);
                Assert.AreEqual(expectedCount, queue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyQueue_PopElement_ShouldThrow()
        {
            var queue = new LinkedQueue<int>();

            queue.Dequeue();
        }

        [TestMethod]
        public void FillQueueWithInitialCapacity_EnqueueAndDequeueElements_AssertCount()
        {
            var queue = new LinkedQueue<int>();

            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(3);
            Assert.AreEqual(1, queue.Count);

            queue.Enqueue(5);
            Assert.AreEqual(2, queue.Count);

            var element = queue.Dequeue();
            Assert.AreEqual(5, element);
            Assert.AreEqual(1, queue.Count);

            var element1 = queue.Dequeue();
            Assert.AreEqual(3, element1);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void SeveralItemsLinkedQueue_ToArray_ShouldReturnItems()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(-2);
            queue.Enqueue(7);

            var array = queue.ToArray();
            var expected = new int[] { 7, -2, 5, 3 };

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void LinkedQueueWithDates_ToArray_ShouldReturnEmptyArray()
        {
            var queue = new LinkedQueue<DateTime>();

            var array = queue.ToArray();
            var expected = new int[0];

            CollectionAssert.AreEqual(expected, array);
        }
    }
}