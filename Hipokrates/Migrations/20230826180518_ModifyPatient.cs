using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hipokrates.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Consultation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdPatient",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdPatient",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdPatient",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdPatient",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Consultation",
                keyColumn: "Id",
                keyValue: 5,
                column: "IdPatient",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_IdPatient",
                table: "Consultation",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "Patient_Consultation",
                table: "Consultation",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Patient_Consultation",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_IdPatient",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Consultation");
        }
    }
}
