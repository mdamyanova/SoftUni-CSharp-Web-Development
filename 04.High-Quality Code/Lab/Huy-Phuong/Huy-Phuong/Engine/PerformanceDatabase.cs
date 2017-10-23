namespace Huy_Phuong.Engine
{
    using System;
    using System.Collections.Generic;

    using Huy_Phuong.Exceptions;
    using Huy_Phuong.Interfaces;
    using Huy_Phuong.Models;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theatresDatabase =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.theatresDatabase.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }
            this.theatresDatabase[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatre = this.theatresDatabase.Keys;
            return theatre;
        }

        public virtual void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime dateTime,
            TimeSpan duration,
            decimal price)
        {
            if (!this.theatresDatabase.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var theatreData = this.theatresDatabase[theatreName];

            var dateTimeAndDuration = dateTime + duration;

            if (CheckOverlappingPerformance(theatreData, dateTime, dateTimeAndDuration))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performanceData = new Performance(theatreName, performanceTitle, dateTime, duration, price);
            theatreData.Add(performanceData);
        }

        public virtual IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theatresDatabase.Keys;
            var allPerformances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performances = this.theatresDatabase[theatre];
                allPerformances.AddRange(performances);
            }
            return allPerformances;
        }

        public virtual IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theatresDatabase.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }
            var asfd = this.theatresDatabase[theatreName];
            return asfd;
        }

        private static bool CheckOverlappingPerformance(
            IEnumerable<Performance> theatreData,
            DateTime dateTime,
            DateTime dateTimeAndDuration)
        {
            foreach (var performance in theatreData)
            {
                var currDateTime = performance.DateTime;
                var currDateTimeAndDuration = performance.DateTime + performance.Duration;

                var isOverlapping = (currDateTime <= dateTime && dateTime <= currDateTimeAndDuration)
                                    || (currDateTime <= dateTimeAndDuration
                                        && dateTimeAndDuration <= currDateTimeAndDuration)
                                    || (dateTime <= currDateTime && currDateTime <= dateTimeAndDuration)
                                    || (dateTime <= currDateTimeAndDuration
                                        && currDateTimeAndDuration <= dateTimeAndDuration);

                if (isOverlapping)
                {
                    return true;
                }
            }
            return false;
        }
    }
}