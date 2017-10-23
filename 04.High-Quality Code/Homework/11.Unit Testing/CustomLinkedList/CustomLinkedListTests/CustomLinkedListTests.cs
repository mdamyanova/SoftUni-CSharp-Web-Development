namespace CustomLinkedListTests
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<string> list;

        [TestInitialize]
        public void InitializeCustomLinkedList()
        {
            this.list = new DynamicList<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueFromIndex_SeveralItemsCustomLinkedList_ShouldThrowExeption()
        {
            this.FillCustomLinkedList(this.list);

            var value = this.list[-2];
        }

        [TestMethod]
        public void GetValueFromIndex_SeveralItemsCustomLinkedList_ShouldReturnValue()
        {
            this.FillCustomLinkedList(this.list);

            var value = this.list[4];

            Assert.AreEqual("dim4o", value, "Required value from index is not as expected");
        }

        [TestMethod]
        public void Add_EmptyCustomLinkedList_ShouldReturnZeroCount()
        {
            this.ClearCustomLinkedList(this.list);

            Assert.AreEqual(0, this.list.Count, "Error start value of list count");
        }

        [TestMethod]
        public void Add_NonEmptyCustomLinkedList_ShouldIncrementCount()
        {
            this.FillCustomLinkedList(this.list);

            Assert.AreEqual(22, this.list.Count, "Error incrementing counter of the list");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_SeveralItemsCustomLinkedList_ShouldThrowExeption()
        {
            this.FillCustomLinkedList(this.list);

            this.list.RemoveAt(30);
        }

        [TestMethod]
        public void RemoveAt_SeveralItemsCustomLinkedList_ShouldReturnRemovedValue()
        {
            this.FillCustomLinkedList(this.list);

            var item = this.list.RemoveAt(11);

            Assert.AreEqual("dobre", item, "Returned value of RemoveAt is not as expected");
        }

        [TestMethod]
        public void Remove_SeveralItemsCustomLinkedList_ShouldReturnIndexOfValue()
        {
            this.FillCustomLinkedList(this.list);

            var index = this.list.Remove("krasivo, meko, puhkavo");

            Assert.AreEqual(14, index, "Error in indexation of elements while removing element");
        }

        [TestMethod]
        public void Remove_EmptyCustomLinkedList_ShouldReturnMinusOne()
        {
            this.ClearCustomLinkedList(this.list);

            var index = this.list.Remove("bym");

            Assert.AreEqual(-1, index, "On empty list, expected index of removing element is -1");
        }

        [TestMethod]
        public void IndexOf_SeveralItemsCustomLinkedList_ShouldReturnIndexOfRequiredItem()
        {
            this.FillCustomLinkedList(this.list);

            var index = this.list.IndexOf("test");

            Assert.AreEqual(17, index, "Not return required index by given value");
        }

        [TestMethod]
        public void IndexOf_EmptyItemsCustomLinkedList_ShouldReturnMinusOne()
        {
            this.ClearCustomLinkedList(this.list);

            var index = this.list.IndexOf("nishto");

            Assert.AreEqual(-1, index, "On empty list, expected index of element is -1");
        }

        [TestMethod]
        public void Contains_SeveralItemsCustomLinkedList_ShouldReturnTrue()
        {
            this.FillCustomLinkedList(this.list);

            var contains = this.list.Contains("lepa brena");

            Assert.AreEqual(true, contains, "Element in list is not found");
        }

        [TestMethod]
        public void Contains_EmptyCustomLinkedList_ShouldReturnFalse()
        {
            this.ClearCustomLinkedList(this.list);

            var contains = this.list.Contains("pesho");

            Assert.AreEqual(false, contains, "Element is not in the list, must return false");
        }

        private void FillCustomLinkedList(DynamicList<string> list)
        {
            this.list.Add("ivan");
            this.list.Add("ivana");
            this.list.Add("pechenkata");
            this.list.Add("boyko");
            this.list.Add("dim4o");
            this.list.Add("koko");
            this.list.Add("chocho");
            this.list.Add("gruh");
            this.list.Add("alele");
            this.list.Add("habibi");
            this.list.Add("spish li");
            this.list.Add("dobre");
            this.list.Add("malko kuchence");
            this.list.Add("ti podarih");
            this.list.Add("krasivo, meko, puhkavo");
            this.list.Add("djale");
            this.list.Add("i am string");
            this.list.Add("test");
            this.list.Add("saban saulic");
            this.list.Add("lepa brena");
            this.list.Add("mile kitic");
            this.list.Add("dragan kojic");
        }

        private DynamicList<string> ClearCustomLinkedList(DynamicList<string> list)
        {
            list = new DynamicList<string>();
            return list;
        }
    }
}