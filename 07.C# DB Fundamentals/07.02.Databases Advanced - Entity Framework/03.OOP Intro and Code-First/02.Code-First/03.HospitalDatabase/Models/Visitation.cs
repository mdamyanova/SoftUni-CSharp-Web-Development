using System;

namespace _03.HospitalDatabase.Models
{
    public class Visitation
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public Doctor Doctor { get; set; }
    }
}