using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class DummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CompanyName", "ContactName", "Country", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "Metropolis", "Acme Corp", "John Doe", "USA", "555-1234", "12345", "NA" },
                    { 2, "456 Oak St", "Springfield", "Globex Inc", "Jane Smith", "USA", "555-5678", "67890", "NA" },
                    { 3, "789 Pine St", "Capital City", "Initech", "Bill Lumbergh", "USA", "555-9012", "11223", "NA" },
                    { 4, "321 Maple St", "Raccoon City", "Umbrella Corp", "Alice Abernathy", "USA", "555-3456", "44556", "NA" },
                    { 5, "654 Cedar St", "Gotham", "Wayne Enterprises", "Bruce Wayne", "USA", "555-7890", "77889", "NA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
