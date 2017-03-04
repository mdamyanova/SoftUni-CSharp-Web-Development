using System;
using System.Collections.Generic;

namespace _03.HospitalDatabase.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool HasMedicalInsurance { get; set; }

        public List<Visitation> Visitations { get; set; } = new List<Visitation>();

        public List<Diagnose> Diagnoses { get; set; } = new List<Diagnose>();

        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
    }
}