using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hipokrates.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false),
                    Plan = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MedicalExam_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Producer = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Room_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false),
                    Plan = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Service_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Substance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Substance_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Substance_Medicament",
                columns: table => new
                {
                    IdSubstance = table.Column<int>(type: "int", nullable: false),
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Substance_Medicament_pk", x => new { x.IdSubstance, x.IdMedicament });
                    table.ForeignKey(
                        name: "Medicament_SubstanceMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Substance_SubstanceMedicament",
                        column: x => x.IdSubstance,
                        principalTable: "Substance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 8000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 5000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Pesel = table.Column<int>(type: "int", nullable: false),
                    InsuranceNumber = table.Column<int>(type: "int", nullable: false),
                    Plan = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Consultation_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Doctor_Consultation",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Room_Consultation",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Service_Consultation",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Specialization_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Doctor_Specializaton",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Patient_Address",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalReferral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    IdMedicalExam = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MedicalReferral_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Doctor_Referral",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "MedicalExam_Referral",
                        column: x => x.IdMedicalExam,
                        principalTable: "MedicalExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Patient_Referral",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Doctor_Prescription",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Patient_Prescription",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdConsultation = table.Column<int>(type: "int", nullable: false),
                    DrugDosage = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Recommendations_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Consultation_Recommendations",
                        column: x => x.IdConsultation,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Patient_Recommendations",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescirptionMedicament_pk", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Medicament_PrescriptionMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_PrescriptionMedicament",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRecommendations = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Recommendation_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Recommendations_Recommendation",
                        column: x => x.IdRecommendations,
                        principalTable: "Recommendations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "MedicalExam",
                columns: new[] { "Id", "Name", "Plan", "Type" },
                values: new object[] { 1, "Morfologia krwi", "Standard", "Badania krwi" });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "Id", "Description", "Name", "Producer" },
                values: new object[,]
                {
                    { 1, "Lek przeciwbólowy", "Apap", "Polfarma" },
                    { 2, "Lek przeciwbólowy", "Ibuprom", "Polfarma" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "FloorNumber", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, 101 },
                    { 2, 1, 102 }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Name", "Plan", "Type" },
                values: new object[,]
                {
                    { 1, "Konsultacja internisty", "Standard", "Konsultacja" },
                    { 2, "Konsultacja laryngoloda", "Standard", "Konsultacja" }
                });

            migrationBuilder.InsertData(
                table: "Substance",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ibuprofen" },
                    { 2, "Paracetamol" },
                    { 3, "Ketoprofen" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "a.nowak@hipokrates.pl", "Anna", "Nowak", "12345" },
                    { 2, "jan.kowalski@example.com", "Jan", "Kowalski", "12345" },
                    { 3, "a.małysz@example.com", "Adam", "Małysz", "12345" },
                    { 4, "w.wojciechowski@hipokrates.com", "Wojciech", "Wojciechowski", "12345" },
                    { 5, "r.romanowski@hipokrates.com", "Roman", "Romanowski", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "BaseSalary", "LicenseNumber" },
                values: new object[,]
                {
                    { 4, 8000m, 333454 },
                    { 5, 8000m, 346765 }
                });

            migrationBuilder.InsertData(
                table: "Nurse",
                columns: new[] { "Id", "BaseSalary" },
                values: new object[] { 1, 5000m });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "InsuranceNumber", "Pesel", "PhoneNumber", "Plan" },
                values: new object[,]
                {
                    { 2, 43234545, 343545425, 333333333, "Standard" },
                    { 3, 3435422, 343235445, 454656323, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Substance_Medicament",
                columns: new[] { "IdMedicament", "IdSubstance" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "IdPatient", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "Polska", 2, "00-116", "Aleje Jerozolimskie" },
                    { 2, "Warszawa", "Polska", 3, "00-116", "Nowy Świat" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "IdDoctor", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Internista" },
                    { 2, 5, "Laryngolog" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdPatient",
                table: "Address",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdDoctor",
                table: "Consultations",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdRoom",
                table: "Consultations",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdService",
                table: "Consultations",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReferral_IdDoctor",
                table: "MedicalReferral",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReferral_IdMedicalExam",
                table: "MedicalReferral",
                column: "IdMedicalExam");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReferral_IdPatient",
                table: "MedicalReferral",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_IdPrescription",
                table: "PrescriptionMedicament",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_IdRecommendations",
                table: "Recommendation",
                column: "IdRecommendations");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_IdConsultation",
                table: "Recommendations",
                column: "IdConsultation");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_IdPatient",
                table: "Recommendations",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_IdDoctor",
                table: "Specialization",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Substance_Medicament_IdMedicament",
                table: "Substance_Medicament",
                column: "IdMedicament");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "MedicalReferral");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicament");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Substance_Medicament");

            migrationBuilder.DropTable(
                name: "MedicalExam");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Substance");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
