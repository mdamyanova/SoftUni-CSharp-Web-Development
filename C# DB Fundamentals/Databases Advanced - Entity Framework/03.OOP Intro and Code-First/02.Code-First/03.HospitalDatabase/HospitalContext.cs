using _03.HospitalDatabase.Models;

namespace _03.HospitalDatabase
{ 
    using System.Data.Entity;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }
        public virtual DbSet<Patient> Patients { get; set; } 
    }
}