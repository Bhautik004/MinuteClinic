using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinuteClinic.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VaccineImage",
                table: "Vaccine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Vaccine",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "City", "ClinicName", "Location", "State", "ZipCode" },
                values: new object[,]
                {
                    { 4, "Los Angeles", "CA Health Center", "7890 Maple Ave", "CA", 90210 },
                    { 5, "Chicago", "Downtown Clinic", "321 Cedar St", "IL", 60601 },
                    { 6, "Denver", "Westside Clinic", "654 Spruce St", "CO", 80202 },
                    { 7, "San Francisco", "Bay Area Clinic", "987 Redwood Rd", "CA", 94102 },
                    { 8, "Miami", "South Beach Clinic", "111 Ocean Dr", "FL", 33139 }
                });

            migrationBuilder.UpdateData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "Address",
                value: "UK");

            migrationBuilder.InsertData(
                table: "Provider",
                columns: new[] { "ProviderId", "Address", "Name" },
                values: new object[,]
                {
                    { 4, "NJ", "Johnson & Johnson" },
                    { 5, "China", "Sinopharm" },
                    { 6, "Germany", "BioNTech" },
                    { 7, "France", "Sanofi" },
                    { 8, "Germany", "CureVac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "VaccineImage",
                table: "Vaccine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Vaccine",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "Address",
                value: "PL");
        }
    }
}
