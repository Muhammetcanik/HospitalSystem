using HospitalMonitoringSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMonitoringSystem
{
   public class AppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=CANIK;Initial Catalog=CodeFirst7;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.PrescriptionMedicines)
                .WithOne(m => m.Medicine)
                .HasForeignKey(m => m.MedicineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Visits)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.PrescriptionMedicines)
                .WithOne(p => p.Prescription)
                .HasForeignKey(p => p.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(p => new { p.PrescriptionId, p.MedicineId });
        }

    }
}
