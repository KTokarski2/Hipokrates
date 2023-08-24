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
    
    public virtual DbSet<Address> Addresses { get; set; } // +
    public virtual DbSet<Consultation> Consultations { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<MedicalExam> MedicalExams { get; set; }
    public virtual DbSet<MedicalReferral> MedicalReferrals { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Nurse> Nurses { get; set; } // +
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<Recommendation> Recommendation { get; set; }
    public virtual DbSet<Recommendations> Recommendations { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<Substance> Substances { get; set; }
    public virtual DbSet<SubstanceMedicament> SubstanceMedicaments { get; set; }
    public virtual DbSet<User> Users { get; set; } //+

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("User_pk");
            entity.ToTable("User");
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Email);
            entity.Property(e => e.Password);
            entity.UseTptMappingStrategy();
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.ToTable("Nurse");
            entity.Property(e => e.BaseSalary).HasDefaultValue(5000m);
            
            modelBuilder.Entity<Nurse>().HasData(
                new Nurse { Id = 1, FirstName = "Alicja", LastName = "Pielęgniarka", Email = "alicja@example.com", Password = "password" },
                new Nurse { Id = 2, FirstName = "Bartosz", LastName = "Opiekun", Email = "bartosz@example.com", Password = "password" },
                new Nurse { Id = 3, FirstName = "Celina", LastName = "Higienistka", Email = "celina@example.com", Password = "password" },
                new Nurse { Id = 4, FirstName = "Damian", LastName = "Ratowniczy", Email = "damian@example.com", Password = "password" },
                new Nurse { Id = 5, FirstName = "Eliza", LastName = "Zdrowotna", Email = "eliza@example.com", Password = "password" }
            );
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");
            entity.Property(e => e.PhoneNumber);
            entity.Property(e => e.Pesel);
            entity.Property(e => e.InsuranceNumber);
            entity.Property(e => e.Plan).HasConversion<string>();
            
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 6, FirstName = "Filip", LastName = "Pacjent", Email = "filip@example.com", Password = "password", PhoneNumber = 123456789, Pesel = 1234567890, InsuranceNumber = 546646, Plan = Plan.Standard },
                new Patient { Id = 7, FirstName = "Gabriela", LastName = "Chory", Email = "gabriela@example.com", Password = "password", PhoneNumber = 987654321, Pesel = 987654321, InsuranceNumber = 4564646, Plan = Plan.Standard },
                new Patient { Id = 8, FirstName = "Hanna", LastName = "Leczenie", Email = "hanna@example.com", Password = "password", PhoneNumber = 543216789, Pesel = 54321678, InsuranceNumber = 453466, Plan = Plan.Premium },
                new Patient { Id = 9, FirstName = "Igor", LastName = "Wyleczony", Email = "igor@example.com", Password = "password", PhoneNumber = 678901234, Pesel = 6789012, InsuranceNumber = 5436446, Plan = Plan.Standard },
                new Patient { Id = 10, FirstName = "Janina", LastName = "Badanie", Email = "janina@example.com", Password = "password", PhoneNumber = 234567890, Pesel = 23456789, InsuranceNumber = 45435456, Plan = Plan.Standard }
            );
        });

        modelBuilder.Entity<MedicalReferral>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("MedicalReferral_pk");
            entity.ToTable("MedicalReferral");
            entity.Property(e => e.DateOfIssue);
            entity.Property(e => e.Description);

            entity
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Referrals)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Doctor_Referral");

            entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Referrals)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Referral");

            entity
                .HasOne(e => e.MedicalExam)
                .WithMany(e => e.Referrals)
                .HasForeignKey(e => e.IdMedicalExam)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("MedicalExam_Referral");
        });

        modelBuilder.Entity<Recommendations>(entity =>
        {
            entity.HasKey(e => new {e.Id}).HasName("Recommendations_pk");
            entity.ToTable("Recommendations");
            entity.Property(e => e.DrugDosage);

            entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Recommendations)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Recommendations");

            entity
                .HasOne(e => e.Consultation)
                .WithMany(e => e.Recommendations)
                .HasForeignKey(e => e.IdConsultation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Consultation_Recommendations");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Recommendation_pk");
            entity.ToTable("Recommendation");
            entity.Property(e => e.Text);

            entity
                .HasOne(e => e.Recommendations)
                .WithMany(e => e.Guidelines)
                .HasForeignKey(e => e.IdRecommendations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Recommendations_Recommendation");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Address_pk");
            entity.ToTable("Address");
            entity.Property(e => e.Street);
            entity.Property(e => e.City);
            entity.Property(e => e.PostalCode);
            entity.Property(e => e.Country);

            entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Address");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");
            entity.Property(e => e.LicenseNumber);
            entity.Property(e => e.BaseSalary).HasDefaultValue(8000m);
            
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 11, FirstName = "Kamil", LastName = "Lekarz", Email = "kamil@example.com", Password = "password", LicenseNumber = 54546565, BaseSalary = 10000m },
                new Doctor { Id = 12, FirstName = "Lena", LastName = "Medycyna", Email = "lena@example.com", Password = "password", LicenseNumber = 43554545, BaseSalary = 12000m },
                new Doctor { Id = 13, FirstName = "Marek", LastName = "Chirurg", Email = "marek@example.com", Password = "password", LicenseNumber = 43545456, BaseSalary = 15000m },
                new Doctor { Id = 14, FirstName = "Natalia", LastName = "Specjalista", Email = "natalia@example.com", Password = "password", LicenseNumber = 4546466, BaseSalary = 13000m },
                new Doctor { Id = 15, FirstName = "Oskar", LastName = "Ortopeda", Email = "oskar@example.com", Password = "password", LicenseNumber = 45464664, BaseSalary = 14000m }
            );
        });

        modelBuilder.Entity<SubstanceMedicament>(entity =>
        {
            entity.HasKey(e => new { e.IdSubstance, e.IdMedicament }).HasName("Substance_Medicament_pk");
            entity.ToTable("Substance_Medicament");
            entity
                .HasOne(e => e.Medicament)
                .WithMany(e => e.SubstancesMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .HasConstraintName("Medicament_SubstanceMedicament");

            entity
                .HasOne(e => e.Substance)
                .WithMany(e => e.SubstanceMedicaments)
                .HasForeignKey(e => e.IdSubstance)
                .HasConstraintName("Substance_SubstanceMedicament");
        });

        modelBuilder.Entity<Substance>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Substance_pk");
            entity.ToTable("Substance");
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Specialization_pk");
            entity.ToTable("Specialization");
            entity.Property(e => e.Name);

            entity
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Specializations)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Doctor_Specializaton");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Service_pk");
            entity.ToTable("Service");
            entity.Property(e => e.Type);
            entity.Property(e => e.Plan).HasConversion<string>();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Room_pk");
            entity.ToTable("Room");
            entity.Property(e => e.RoomNumber);
            entity.Property(e => e.FloorNumber);
        });

        modelBuilder.Entity<PrescriptionMedicament>(entity =>
        {
            entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("PrescirptionMedicament_pk");
            entity.ToTable("PrescriptionMedicament");

            entity
                .HasOne(e => e.Medicament)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Medicament_PrescriptionMedicament");

            entity
                .HasOne(e => e.Prescription)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Prescription_PrescriptionMedicament");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Prescription_pk");
            entity.ToTable("Prescription");
            entity.Property(e => e.DateOfIssue);
            entity.Property(e => e.ExpiryDate);

            entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Prescription");

            entity
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Doctor_Prescription");
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Medicament_pk");
            entity.ToTable("Medicament");
            entity.Property(e => e.Name);
            entity.Property(e => e.Producer);
            entity.Property(e => e.Description);
        });

        modelBuilder.Entity<MedicalExam>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("MedicalExam_pk");
            entity.ToTable("MedicalExam");
            entity.Property(e => e.Name);
            entity.Property(e => e.Type);
            entity.Property(e => e.Plan).HasConversion<string>();
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Consultation_pk");
            entity.Property(e => e.Status).HasConversion<string>();
            entity.Property(e => e.Date);
            entity.Property(e => e.Time);

            entity
                .HasOne(e => e.Room)
                .WithMany(e => e.Consultations)
                .HasForeignKey(e => e.IdRoom)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Room_Consultation");

            entity.HasOne(e => e.Service)
                .WithMany(e => e.Consultations)
                .HasForeignKey(e => e.IdService)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Service_Consultation");

            entity.HasOne(e => e.Doctor)
                .WithMany(e => e.Consultations)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Doctor_Consultation");
        });
    }

}