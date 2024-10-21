using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinuteClinic.Migrations
{
    /// <inheritdoc />
    public partial class SeedProviderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provider",
                columns: new[] { "ProviderId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "NY", "Moderna" },
                    { 2, "PL", "AstraZeneca" },
                    { 3, "IL", "Pfizer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3);
        }
    }
}
