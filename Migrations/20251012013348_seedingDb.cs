using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CUTDataScienceClub.Migrations
{
    /// <inheritdoc />
    public partial class seedingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CurrentLevel", "FullName", "Program", "RegNumber" },
                values: new object[,]
                {
                    { 1, "100", "Alice Johnson", "Data Science", "DSC001" },
                    { 2, "200", "Bob Smith", "Data Science", "DSC002" },
                    { 3, "300", "Carol Lee", "Statistics", "DSC003" },
                    { 4, "400", "David Kim", "Computer Science", "DSC004" },
                    { 5, "200", "Eva Brown", "Data Science", "DSC005" },
                    { 6, "100", "Frank White", "Mathematics", "DSC006" },
                    { 7, "300", "Grace Green", "Data Science", "DSC007" },
                    { 8, "400", "Henry Black", "Statistics", "DSC008" },
                    { 9, "200", "Ivy Blue", "Computer Science", "DSC009" },
                    { 10, "100", "Jack Red", "Mathematics", "DSC010" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
