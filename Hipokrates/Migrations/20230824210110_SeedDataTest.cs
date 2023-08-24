using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hipokrates.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "alicja@example.com", "Alicja", "Pielęgniarka", "password" },
                    { 2, "bartosz@example.com", "Bartosz", "Opiekun", "password" },
                    { 3, "celina@example.com", "Celina", "Higienistka", "password" },
                    { 4, "damian@example.com", "Damian", "Ratowniczy", "password" },
                    { 5, "eliza@example.com", "Eliza", "Zdrowotna", "password" },
                    { 6, "filip@example.com", "Filip", "Pacjent", "password" },
                    { 7, "gabriela@example.com", "Gabriela", "Chory", "password" },
                    { 8, "hanna@example.com", "Hanna", "Leczenie", "password" },
                    { 9, "igor@example.com", "Igor", "Wyleczony", "password" },
                    { 10, "janina@example.com", "Janina", "Badanie", "password" },
                    { 11, "kamil@example.com", "Kamil", "Lekarz", "password" },
                    { 12, "lena@example.com", "Lena", "Medycyna", "password" },
                    { 13, "marek@example.com", "Marek", "Chirurg", "password" },
                    { 14, "natalia@example.com", "Natalia", "Specjalista", "password" },
                    { 15, "oskar@example.com", "Oskar", "Ortopeda", "password" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "BaseSalary", "LicenseNumber" },
                values: new object[,]
                {
                    { 11, 10000m, 54546565 },
                    { 12, 12000m, 43554545 },
                    { 13, 15000m, 43545456 },
                    { 14, 13000m, 4546466 },
                    { 15, 14000m, 45464664 }
                });

            migrationBuilder.InsertData(
                table: "Nurse",
                columns: new[] { "Id", "BaseSalary" },
                values: new object[,]
                {
                    { 1, 5000m },
                    { 2, 5000m },
                    { 3, 5000m },
                    { 4, 5000m },
                    { 5, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "InsuranceNumber", "Pesel", "PhoneNumber", "Plan" },
                values: new object[,]
                {
                    { 6, 546646, 1234567890, 123456789, "Standard" },
                    { 7, 4564646, 987654321, 987654321, "Standard" },
                    { 8, 453466, 54321678, 543216789, "Premium" },
                    { 9, 5436446, 6789012, 678901234, "Standard" },
                    { 10, 45435456, 23456789, 234567890, "Standard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Nurse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nurse",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nurse",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nurse",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nurse",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
