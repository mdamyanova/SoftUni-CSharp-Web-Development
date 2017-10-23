namespace _02.LinkedQueueTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _02.LinkedQueue;

    [TestClass]
    public class LinkedQueueTests
    {
        private LinkedQueue<string> queue;

        [TestInitialize]
        public void InitializeQueue()
        {
           this.queue = new LinkedQueue<string>();
        }

        [TestMethod]
        public void Deuqeue_OneElementQueue_ShouldReturnExpectedElement()
        {
            this.queue.Enqueue("pesho");
            var element = this.queue.Dequeue();

            Assert.AreEqual("pesho", element);
        }

        [TestMethod]
        public void Dequeue_SeveralElementsQueue_ShouldReturnExpectedElement()
        {
            this.queue.Enqueue("mariika");
            this.queue.Enqueue("kolio");
            this.queue.Enqueue("gosho");

            var element = this.queue.Dequeue();
             
            Assert.AreEqual("mariika", element);
        }

        [TestMethod]
        public void EnqueueSeveralElements_EmptyQueue_ShouldIncrementCount()
        {
            this.queue.Enqueue("petka");
            this.queue.Enqueue("jivka");
            this.queue.Enqueue("spaska");
            var count = this.queue.Count;

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void EnqueueAndDequeue_SeveralElementsQueue_ShouldChangeCount()
        {
            this.queue.Enqueue("fikret");
            this.queue.Enqueue("sancho");
            this.queue.Enqueue("pena");
            
            Assert.AreEqual(3, this.queue.Count);
            this.queue.Dequeue();     
            Assert.AreEqual(2, this.queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldThrowExeption()
        {
            this.queue.Dequeue();
        }
    }
}