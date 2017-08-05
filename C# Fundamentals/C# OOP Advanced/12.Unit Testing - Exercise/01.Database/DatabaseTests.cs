using System;
using NUnit.Framework;

namespace _01.Database
{
    public class DatabaseTests
    {
        private const int FullDataCapacityCount = 16;
        private const int SeveralElementsCount = 5;
        private Database database;

        [SetUp]
        public void TestInit()
        {
            this.database = new Database();
        }

        //constructor tests

        [Test]
        public void InitDatabaseWithFullCapacity()
        {
            var fullDatabase = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(FullDataCapacityCount, fullDatabase.Count);
        }

        [Test]
        public void InitDatabaseWithFewElements()
        {
            var fewElementsDatabase = new Database(1, 2, 3, 4, 5);

            Assert.AreEqual(3, fewElementsDatabase.Count);
        }    

        //Add method tests

        [Test]
        public void AddElementToEmptyDatabase()
        {
            AddSeveralElements(database);

            Assert.AreEqual(SeveralElementsCount, this.database.Count);
        }

        [Test]
        public void AddExcatlyFullCapacityElements()
        {
            AddFullCapacityElements(this.database);

            Assert.AreEqual(FullDataCapacityCount, this.database.Count);
        }

        [Test]
        public void AddElementToFullDatabase()
        {
            AddFullCapacityElements(this.database);
            var exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(17));

            Assert.AreEqual(exception.Message, "Can't add more elements.");
        }    

        //Remove method tests

        [Test]
        public void RemoveElementOfEmptyDatabase()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.database.Remove());
            Assert.AreEqual("Data is empty.", exception.Message);
        }

        [Test]
        public void RemoveElementOfDatabase()
        {
            AddSeveralElements(this.database);
            this.database.Remove();
             
            Assert.AreEqual(SeveralElementsCount - 1, this.database.Count);
        }

        [Test]
        public void RemoveAllElementsOfFullDatabase()
        {
            AddFullCapacityElements(this.database);
            RemoveFullCapacityElements(this.database);

            Assert.AreEqual(0, this.database.Count);
        }

        //Fetch method tests

        [Test]
        public void FetchEmptyDatabase()
        {
            var result = this.database.Fetch();

            Assert.AreEqual(new int[0], result);
        }

        [Test]
        public void FetchDatabaseWithSeveralElements()
        {
            AddSeveralElements(database);
            var result = this.database.Fetch();

            Assert.AreEqual(SeveralElementsCount, result.Length);
        }

        [Test]
        public void FetchFullDatabase()
        {
            AddFullCapacityElements(this.database);
            var result = this.database.Fetch();

            Assert.AreEqual(FullDataCapacityCount, result.Length);
        }

        private static void AddSeveralElements(Database database)
        {
            for (int i = 0; i < SeveralElementsCount; i++)
            {
                database.Add(i + 1);
            }
        }

        private static void AddFullCapacityElements(Database database)
        {
            for (int i = 0; i < FullDataCapacityCount; i++)
            {
                database.Add(i + 1);
            }
        }

        private static void RemoveFullCapacityElements(Database database)
        {
            for (int i = 0; i < FullDataCapacityCount; i++)
            {
                database.Remove();
            }
        }
    }
}