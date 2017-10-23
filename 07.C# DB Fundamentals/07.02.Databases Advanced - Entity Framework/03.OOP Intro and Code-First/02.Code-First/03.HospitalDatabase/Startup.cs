using System;
using _03.HospitalDatabase.Models;

namespace _03.HospitalDatabase
{
    class Startup
    {
        static void Main()
        {
            var diagnose = new Diagnose
            {
                Name = "Prepivane s domashna rakia",
                Comment = "Bez komentar"
            };

            var doctorRadeva = new Doctor
            {
                Name = "Radeva",
                Specialty = "Specialist alkoholni otravqniq"
            };

            var visitation = new Visitation()
            {
                Doctor = doctorRadeva, Date = DateTime.Now
            };

            doctorRadeva.Visitations.Add(visitation);

            var medicament = new Medicament() {Name = "Zeleva chorba"};
            var patient1 = new Patient()
            {
                FirstName = "Petar",
                LastName = "Trifonov",
                Address = "Babinata Kashturka 4",
                Email = "petar.trifonov@gmail.com",
                DateOfBirth = new DateTime(1982, 04, 18),
                Diagnoses = { diagnose, diagnose },
                Visitations = { visitation },
                Medicaments = { medicament },
                HasMedicalInsurance = false
            };

            var context = new HospitalContext();
            context.Patients.Add(patient1);
            context.SaveChanges();
        }
    }
}