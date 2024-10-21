using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinuteClinic.Migrations
{
    /// <inheritdoc />
    public partial class SeedClinicData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "City", "ClinicName", "Location", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Anytown", "NY Clinic", "1234 Elm St", "NY", 12345 },
                    { 2, "Othertown", "IL Clinic", "5678 Oak St", "IL", 45678 },
                    { 3, "Thirdtown", "MI Clinic", "91011 Pine St", "MI", 90012 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 3);
        }
    }
}
