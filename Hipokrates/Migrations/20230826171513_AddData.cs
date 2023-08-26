using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hipokrates.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consultation",
                columns: new[] { "Id", "Date", "IdDoctor", "IdRoom", "IdService", "Status", "Time" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, "Finished", new TimeSpan(0, 12, 0, 0, 0) },
                    { 2, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, "Planned", new TimeSpan(0, 15, 30, 0, 0) },
                    { 3, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, "Canceled", new TimeSpan(0, 8, 45, 0, 0) },
                    { 4, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, "Registered", new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, "Planned", new TimeSpan(0, 16, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "DrugDosage", "IdConsultation", "IdPatient" },
                values: new object[,]
                {
                    { 1, "3x apap noc w dzień", 1, 3 },
                    { 2, "", 2, 3 },
                    { 3, "", 3, 3 },
                    { 4, "", 4, 3 },
                    { 5, "", 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Recommendation",
                columns: new[] { "Id", "IdRecommendations", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Pić tylko wodę Fidżi" },
                    { 2, 1, "Chodzić spać przed 21:37" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recommendation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recommendation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
