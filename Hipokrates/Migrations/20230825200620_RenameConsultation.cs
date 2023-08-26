using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hipokrates.Migrations
{
    /// <inheritdoc />
    public partial class RenameConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Consultations",
                newName: "Consultation");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_IdService",
                table: "Consultation",
                newName: "IX_Consultation_IdService");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_IdRoom",
                table: "Consultation",
                newName: "IX_Consultation_IdRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_IdDoctor",
                table: "Consultation",
                newName: "IX_Consultation_IdDoctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Consultation",
                newName: "Consultations");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_IdService",
                table: "Consultations",
                newName: "IX_Consultations_IdService");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_IdRoom",
                table: "Consultations",
                newName: "IX_Consultations_IdRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_IdDoctor",
                table: "Consultations",
                newName: "IX_Consultations_IdDoctor");
        }
    }
}
