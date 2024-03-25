using CliMg.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace CliMg.Data
{
    public class MedContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public MedContext(DbContextOptions<MedContext> options) : base(options)
        {
        }
    }
}
