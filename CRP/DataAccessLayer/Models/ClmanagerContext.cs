using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public class ClmanagerContext : DbContext
{
    public ClmanagerContext()
    {
    }

    public ClmanagerContext(DbContextOptions<ClmanagerContext> options)
        : base(options)
    {
    }

    public  DbSet<Illness> Illnesses { get; set; }
    
    public  DbSet<IllnessSymptom> IllnessSymptoms { get; set; }

    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Symptom> Symptoms { get; set; }
}
