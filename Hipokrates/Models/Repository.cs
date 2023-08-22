using Microsoft.EntityFrameworkCore;

namespace Hipokrates.Models;

public class Repository : DbContext
{
    public Repository()
    {
        
    }

    public Repository(DbContextOptions<Repository> options) : base(options)
    {
        
    }
    
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Consultation> Consultations { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<MedicalExam> MedicalExams { get; set; }
    public virtual DbSet<MedicalReferral> MedicalReferrals { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Nurse> Nurses { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<Recommendation> Recommendation { get; set; }
    public virtual DbSet<Recommendations> Recommendations { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<Substance> Substances { get; set; }
    public virtual DbSet<SubstanceMedicament> SubstanceMedicaments { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}