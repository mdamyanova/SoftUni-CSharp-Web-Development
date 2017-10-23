using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huy_PhuongTests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;

    using Huy_Phuong.Engine;
    using Huy_Phuong.Exceptions;
    using Huy_Phuong.Interfaces;
    using Huy_Phuong.Models;

    using Moq;

    [TestClass]
    public class IPerformanceDatabaseTests
    {
        [TestMethod]
        public void EmptyDatabase_ListTheatres_ShouldReturnZeroCount()
        {
            //Arrange
            var database = new PerformanceDatabase();

            //Act
            var listedDatabase = database.ListTheatres().Count();
            var expectedCount = 0;

            //Assert
            Assert.AreEqual(expectedCount, listedDatabase);
        }

        [TestMethod]
        public void SeveralTheatres_ListTheatres_ShouldReturnListedTheatres()
        {
            //Arrange
            var database = new PerformanceDatabase();

            //Act
            database.AddTheatre("Theatre Gosho");
            database.AddTheatre("Theatre Petka");
            database.AddTheatre("Ivana Theatre");

            var listed = database.ListTheatres();
            var expected = new List<IEnumerable> { "Ivana Theatre", "Theatre Gosho", "Theatre Petka" };
        
            //Assert
            CollectionAssert.AreEqual(expected.ToList(), listed.ToList());
        }


        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void EmptyDatabase_AddPerformance_ShouldReturnExceptionMessage()
        {
            //Arrange
            var database = new PerformanceDatabase();

            //Act
            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName = "Theatre Tear and Laught";
            string performanceTitle = "Duende";
            DateTime startDateTime = DateTime.ParseExact("20.06.2010 22:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("2:15");
            decimal ticketPrice = 5.50m;

            database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
        }

        [TestMethod]
        public void SeveralTheatres_AddPerformanceToActualTheatre_ShouldAddPerformance()
        {
            //Arrange
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre 199");
            database.AddTheatre("Theatre Ivan Vazov");

            //Act
            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName = "Theatre 199";
            string performanceTitle = "Duende";
            DateTime startDateTime = DateTime.ParseExact("20.06.2010 22:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("2:15");
            decimal ticketPrice = 5.50m;

            database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
            var listedPerformance = database.ListPerformances("Theatre 199");
            var expectedPerformance = new Performance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
         
            //Assert
            Assert.AreEqual(expectedPerformance.ToString(), listedPerformance.First().ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void SeveralTheatres_AddPerformanceToAlreadyAddedPerformance_ShouldThrowExceptionMessage()
        {
            //Arrange
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre 199");
            database.AddTheatre("Theatre Ivan Vazov");

            //Act
            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName = "Theatre 199";
            string performanceTitle = "Duende";
            DateTime startDateTime = DateTime.ParseExact("20.06.2010 22:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("2:15");
            decimal ticketPrice = 5.50m;

            string theatreName1 = "Theatre 199";
            string performanceTitle1 = "Shishi";
            DateTime startDateTime1 = DateTime.ParseExact("20.06.2010 22:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration1 = TimeSpan.Parse("2:15");
            decimal ticketPrice1 = 5.50m;

            database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
            database.AddPerformance(theatreName1, performanceTitle1, startDateTime1, duration1, ticketPrice1);             
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void EmptyDatabase_ListPerformances_ShouldThrowException()
        {
            var database = new PerformanceDatabase();
            var listed = database.ListPerformances("Theatre");
        }

        [TestMethod]
        public void SeveralTheatresWithPerformances_ListPerformances_ShouldReturnPerformancesForGivenTheatre()
        {
            //Arrange
            IPerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre 199");
            database.AddTheatre("Theatre Ivan Vazov");

            //Act
            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName = "Theatre 199";
            string performanceTitle = "Duende";
            DateTime startDateTime = DateTime.ParseExact("20.06.2010 22:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("2:15");
            decimal ticketPrice = 5.50m;

            string theatreName1 = "Theatre Ivan Vazov";
            string performanceTitle1 = "Shishi";
            DateTime startDateTime1 = DateTime.ParseExact("21.06.2010 21:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration1 = TimeSpan.Parse("1:30");
            decimal ticketPrice1 = 10.00m;

            database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
            database.AddPerformance(theatreName1, performanceTitle1, startDateTime1, duration1, ticketPrice1);

            List<Performance> listed199 = database.ListPerformances("Theatre 199").ToList();
            List<Performance> listedVazov = database.ListPerformances("Theatre Ivan Vazov").ToList();

            var expectedListed199 = new Performance(theatreName, performanceTitle, startDateTime, duration, ticketPrice);
            var expectedListedVazov = new Performance(theatreName1, performanceTitle1, startDateTime1, duration1, ticketPrice1);
            
            //Assert
            Assert.AreEqual(expectedListed199.ToString(), listed199.First().ToString());
            Assert.AreEqual(expectedListedVazov.ToString(), listedVazov.First().ToString());
        }
    }
}
