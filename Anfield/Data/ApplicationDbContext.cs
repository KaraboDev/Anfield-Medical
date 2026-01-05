using Anfield.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Anfield.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Anfield.Models.ChronicMedication>? ChronicMedication { get; set; }
        //public DbSet<Anfield.Models.Patient>? Patient { get; set; }
        //public DbSet<Anfield.Models.ExpectingPatients>? ExpectingPatients { get; set; }
        public DbSet<Anfield.Models.Admin>? Admins { get; set; }
        public DbSet<Anfield.Models.Doctor>? Doctors { get; set;}
        public DbSet<Anfield.Models.SystemUsers>? SystemUsers { get; set; }
        public DbSet<Anfield.Models.BookAppointment>? BookAppointment { get; set; }
        public DbSet<Anfield.Models.PatientAppointments>? PatientAppointments { get; set; }
        public DbSet<Anfield.Models.Vaccine>? Vaccine { get; set; }
        public DbSet<Anfield.Models.Pathology>? Pathology { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Newborn> Newborns { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<LaborAndDelivery> LaborAndDeliveries { get; set; }




    }
}