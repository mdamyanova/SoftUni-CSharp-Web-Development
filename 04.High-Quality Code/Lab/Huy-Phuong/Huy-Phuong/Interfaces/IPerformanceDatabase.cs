namespace Huy_Phuong.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Huy_Phuong.Models;

    /// <summary>
    /// Contract with nessesery methods for theatre database
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds the theatre.
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Lists the theatres.
        /// </summary>
        /// <returns>Collection of theatres</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds the performance.
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        /// <param name="performanceTitle">The performance title.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="price">The price.</param>
        void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price);

        /// <summary>
        /// Lists all performances.
        /// </summary>
        /// <returns>Collection of performances</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists the performances.
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        /// <returns>Collection of performances for the requested theatre</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}