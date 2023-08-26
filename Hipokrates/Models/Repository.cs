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
                new Nurse {Id = 1, FirstName = "Anna", LastName = "Nowak", Email = "a.nowak@hipokrates.pl", Password = "12345", BaseSalary = 5000m}
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
                new Patient
                {
                    Id = 2, FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@example.com", 
                    Password = "12345", PhoneNumber = 333333333, Pesel = 343545425, InsuranceNumber = 43234545,
                    Plan = Plan.Standard
                },
                new Patient
                {
                    Id = 3, FirstName = "Adam", LastName = "Małysz", Email = "a.małysz@example.com", Password = "12345",
                    PhoneNumber = 454656323, Pesel = 343235445, InsuranceNumber = 3435422, Plan = Plan.Premium
                }
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

            modelBuilder.Entity<Recommendations>().HasData(
                new Recommendations {Id = 1, DrugDosage = "3x apap noc w dzień", IdPatient = 3, IdConsultation = 1},
                new Recommendations {Id = 2, DrugDosage = "", IdPatient = 3, IdConsultation = 2},
                new Recommendations {Id = 3, DrugDosage = "", IdPatient = 3, IdConsultation = 3},
                new Recommendations {Id = 4, DrugDosage = "", IdPatient = 3, IdConsultation = 4},
                new Recommendations {Id = 5, DrugDosage = "", IdPatient = 3, IdConsultation = 5}
                    
            );
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
            modelBuilder.Entity<Recommendation>().HasData(
                new Recommendation {Id = 1, IdRecommendations = 1, Text = "Pić tylko wodę Fidżi"},
                new Recommendation {Id = 2, IdRecommendations = 1, Text = "Chodzić spać przed 21:37"}
            );
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

            modelBuilder.Entity<Address>().HasData(
                new Address {Id = 1, Street = "Aleje Jerozolimskie", City = "Warszawa", PostalCode = "00-116", Country = "Polska", IdPatient = 2},
                new Address {Id = 2, Street = "Nowy Świat", City = "Warszawa", PostalCode = "00-116", Country = "Polska", IdPatient = 3}
            );
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");
            entity.Property(e => e.LicenseNumber);
            entity.Property(e => e.BaseSalary).HasDefaultValue(8000m);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 4, FirstName = "Wojciech", LastName = "Wojciechowski", Email = "w.wojciechowski@hipokrates.com", Password = "12345",
                    LicenseNumber = 333454, BaseSalary = 8000m
                },
                new Doctor
                {
                    Id = 5, FirstName = "Roman", LastName = "Romanowski", Email = "r.romanowski@hipokrates.com", Password = "12345",
                    LicenseNumber = 346765, BaseSalary = 8000m
                }
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

            modelBuilder.Entity<SubstanceMedicament>().HasData(
                new SubstanceMedicament {IdMedicament = 1, IdSubstance = 1},
                new SubstanceMedicament {IdMedicament = 2, IdSubstance = 2}
            );
        });

        modelBuilder.Entity<Substance>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Substance_pk");
            entity.ToTable("Substance");
            entity.Property(e => e.Name);

            modelBuilder.Entity<Substance>().HasData(
                new Substance {Id = 1, Name = "Ibuprofen"},
                new Substance {Id = 2, Name  = "Paracetamol"},
                new Substance {Id = 3, Name = "Ketoprofen"}
                
            );
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

            modelBuilder.Entity<Specialization>().HasData(
                new Specialization {Id = 1, Name = "Internista", IdDoctor = 4},
                new Specialization {Id = 2, Name = "Laryngolog", IdDoctor = 5}
            );
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Service_pk");
            entity.ToTable("Service");
            entity.Property(e => e.Type);
            entity.Property(e => e.Plan).HasConversion<string>();

            modelBuilder.Entity<Service>().HasData(
                new Service {Id = 1, Name = "Konsultacja internisty", Plan = Plan.Standard, Type = "Konsultacja"},
                new Service {Id = 2, Name = "Konsultacja laryngoloda", Plan = Plan.Standard, Type = "Konsultacja"}
            );
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Room_pk");
            entity.ToTable("Room");
            entity.Property(e => e.RoomNumber);
            entity.Property(e => e.FloorNumber);

            modelBuilder.Entity<Room>().HasData(
                new Room {Id = 1, RoomNumber = 101, FloorNumber = 1},
                new Room {Id = 2, RoomNumber = 102, FloorNumber = 1}
            );
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

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament {Id = 1, Name = "Apap", Producer ="Polfarma", Description = "Lek przeciwbólowy"},
                new Medicament {Id = 2, Name = "Ibuprom", Producer = "Polfarma", Description = "Lek przeciwbólowy"}
            );
        });

        modelBuilder.Entity<MedicalExam>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("MedicalExam_pk");
            entity.ToTable("MedicalExam");
            entity.Property(e => e.Name);
            entity.Property(e => e.Type);
            entity.Property(e => e.Plan).HasConversion<string>();

            modelBuilder.Entity<MedicalExam>().HasData(
                new MedicalExam {Id = 1, Name = "Morfologia krwi", Type = "Badania krwi", Plan = Plan.Standard}
            );
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => new { e.Id }).HasName("Consultation_pk");
            entity.ToTable("Consultation");
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

            entity.HasOne(e => e.Patient)
                .WithMany(e => e.Consultations)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Consultation");

            modelBuilder.Entity<Consultation>().HasData(
                new Consultation {Id = 1, Status = Status.Finished, Date = DateTime.ParseExact("11.07.2023","dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), Time = TimeSpan.Parse("12:00"), IdRoom = 1, IdService = 1, IdDoctor = 4, IdPatient = 3},
                new Consultation {Id = 2, Status = Status.Planned, Date = DateTime.ParseExact("12.09.2023","dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), Time = TimeSpan.Parse("15:30"), IdRoom = 1, IdService = 1, IdDoctor = 4, IdPatient = 3},
                new Consultation {Id = 3, Status = Status.Canceled, Date = DateTime.ParseExact("12.05.2023","dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), Time = TimeSpan.Parse("8:45"), IdRoom = 1, IdService = 1, IdDoctor = 4, IdPatient = 3},
                new Consultation {Id = 4, Status = Status.Registered, Date = DateTime.ParseExact("11.04.2024","dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), Time = TimeSpan.Parse("11:00"), IdRoom = 1, IdService = 1, IdDoctor = 4, IdPatient = 3},
                new Consultation {Id = 5, Status = Status.Planned, Date = DateTime.ParseExact("30.09.2023","dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), Time = TimeSpan.Parse("16:00"), IdRoom = 1, IdService = 1, IdDoctor = 4, IdPatient = 3}
            );
        });
    }

}