using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CUTDataScienceClub.Migrations
{
    /// <inheritdoc />
    public partial class clubInforAndOtherChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrimaryColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInformations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClubInformations",
                columns: new[] { "Id", "About", "Address", "ContactPerson", "Email", "FacebookUrl", "FoundedDate", "InstagramUrl", "LinkedInUrl", "LogoUrl", "Mission", "Name", "Phone", "PrimaryColor", "SecondaryColor", "ShortDescription", "TwitterUrl", "Vision", "WebsiteUrl" },
                values: new object[] { 1, "CUT Data Science Club (CUT DSC) brings together students interested in data science for workshops, projects and community events.", "Campus Main Hall", "Club President", "contact@cutdsc.example", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Foster data literacy and practical skills through workshops and projects.", "CUT Data Science Club", "+1234567890", "#7c3aed", "#3b82f6", "Campus club for data science enthusiasts", null, "Be the leading student data science community on campus.", "https://cutdsc.example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubInformations");
        }
    }
}
