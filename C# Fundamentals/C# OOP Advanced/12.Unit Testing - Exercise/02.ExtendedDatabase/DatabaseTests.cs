using System;
using NUnit.Framework;
using _02.ExtendedDatabase.Models;

namespace _02.ExtendedDatabase
{
    public class DatabaseTests
    {
        private const int FullDataCapacityCount = 16;
        private const int SeveralElementsCount = 5;
        private static readonly Person[] people =
        {
            new Person(1, "petka"),
            new Person(2, "pen4o0"),
            new Person(3, "iwka"),
            new Person(4, "nedelya"),
            new Person(5, "srbete"),
            new Person(6, "biraimezeta"),
            new Person(7, "aloda"),
            new Person(8, "kottakoa"),
            new Person(9, "sexy666"),
            new Person(10, "gotiniq"),
            new Person(11, "biri4ka"),
            new Person(12, "caca"),
            new Person(13, "cecatrepni"),
            new Person(14, "lo6omie"),
            new Person(15, "ikokatepetuk"),
            new Person(16, "nzve4e")
        };
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
            var fullDatabase = new Database(people);

            Assert.AreEqual(FullDataCapacityCount, fullDatabase.Count);
        }

        [Test]
        public void InitDatabaseWithFewElements()
        {
            var fewElementsDatabase = new Database(new Person(44, "pyrwi"), new Person(55, "wtori"), new Person(66, "dvaiseipeti"));

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
            var exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(666, "g0shk0")));

            Assert.AreEqual("Can't add more elements.", exception.Message);
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

        //FindById method tests

        [Test]
        public void FindByIdWorksProperly()
        {
            AddSeveralElements(this.database);
            var result = this.database.FindById(16);

            Assert.AreEqual(16, result.Id);
        }

        [Test]
        public void FindByIdWithUnexistingId()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.database.FindById(9098));
            
            Assert.AreEqual("There's no user with this id.", exception.Message);
        }

        [Test]
        public void FindByIdWithNegativeId()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-9098));

            Assert.AreEqual("Id can't be negative.\r\nParameter name: id", exception.Message);
        }


        //FindByUsername method tests

        [Test]
        public void FindByUsernameWorksProperly()
        {
            AddSeveralElements(this.database);
            var result = this.database.FindByUsername("nzbro0");

            Assert.AreEqual("nzbro0", result.Username);
        }

        [Test]
        public void FindByUsernameWithInvalidUsername()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("unexisting"));

            Assert.AreEqual("There's no user with this username.", exception.Message);
        }

        [Test]
        public void FindByUsernameWithNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));

            Assert.AreEqual("Person can't be null.\r\nParameter name: username", exception.Message);
        }

        private static void AddSeveralElements(Database database)
        {
            for (int i = 0; i < SeveralElementsCount; i++)
            {
                database.Add(new Person(i + FullDataCapacityCount, "nzbro" + i));
            }
        }

        private static void AddFullCapacityElements(Database database)
        {
            for (int i = 0; i < FullDataCapacityCount; i++)
            {
                database.Add(new Person(i + FullDataCapacityCount, "nzbro" + i));
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