namespace Huy_Phuong.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(
            string theatreName,
            string performanceName,
            DateTime dateTime,
            TimeSpan duration,
            decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceName = performanceName;
            this.DateTime = dateTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName { get; }

        public string PerformanceName { get; }

        public DateTime DateTime { get; }

        public TimeSpan Duration { get; }

        protected internal decimal Price { get; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            var compareTo = this.DateTime.CompareTo(otherPerformance.DateTime);
            return compareTo;
        }

        public override string ToString()
        {
            var result = string.Format(
                "Performance( {0}, {1}, {2}, {3}, {4})",
                this.TheatreName,
                this.PerformanceName,
                this.DateTime.ToString("dd.MM.yyyy HH:mm"),
                this.Duration.ToString("hh':'mm"),
                this.Price.ToString("f2"));
            return result;
        }
    }
}