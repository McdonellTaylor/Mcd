using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CUTDataScienceClub.Migrations
{
    /// <inheritdoc />
    public partial class creatingEventsTableAndSeedingTheTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Organizer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "IsPublished", "Location", "Organizer", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "A beginner-friendly intro to data science concepts.", new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), true, "Room A1", "DSC", new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Intro to Data Science" },
                    { 2, "Hands-on session on using Python for data analysis.", new DateTime(2025, 11, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), true, "Lab 2", "DSC", new DateTime(2025, 11, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), "Python for Analysis" },
                    { 3, "Probability and statistics refresher.", new DateTime(2025, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), true, "Room B3", "Math Dept", new DateTime(2025, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Statistics Workshop" },
                    { 4, "Overview of supervised and unsupervised learning.", new DateTime(2025, 11, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), true, "Auditorium", "DSC", new DateTime(2025, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), "Machine Learning 101" },
                    { 5, "Create compelling visuals with Tableau.", new DateTime(2025, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), true, "Lab 1", "DSC", new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Data Viz with Tableau" },
                    { 6, "Intro to R and tidyverse.", new DateTime(2025, 12, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), true, "Room C2", "Stats Club", new DateTime(2025, 12, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "R for Data Science" },
                    { 7, "Talk on scalable data systems.", new DateTime(2025, 12, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), true, "Conference Hall", "CS Dept", new DateTime(2025, 12, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), "Big Data Architectures" },
                    { 8, "Natural Language Processing primer.", new DateTime(2026, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), true, "Room D1", "AI Group", new DateTime(2026, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "NLP Basics" },
                    { 9, "How to approach Kaggle problems.", new DateTime(2026, 1, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), true, "Lab 3", "DSC", new DateTime(2026, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Kaggle Competition Prep" },
                    { 10, "Panel on ethical considerations in AI.", new DateTime(2026, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), true, "Auditorium", "Philosophy Dept", new DateTime(2026, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), "Ethics in AI" },
                    { 11, "Two-day bootcamp on ETL and pipelines.", new DateTime(2026, 2, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), true, "Workshop Room", "DSC", new DateTime(2026, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Data Engineering Bootcamp" },
                    { 12, "Analyzing temporal data with ARIMA and more.", new DateTime(2026, 2, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), true, "Room B2", "Stats Club", new DateTime(2026, 2, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Time Series Analysis" },
                    { 13, "Techniques for communicating results.", new DateTime(2026, 2, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), true, "Room A2", "Communications", new DateTime(2026, 2, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), "Data Storytelling" },
                    { 14, "Intro to deep neural networks.", new DateTime(2026, 3, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), true, "Lab 4", "AI Group", new DateTime(2026, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "Deep Learning Workshop" },
                    { 15, "Meet industry recruiters and alumni.", new DateTime(2026, 3, 12, 20, 0, 0, 0, DateTimeKind.Unspecified), true, "Conference Hall", "DSC", new DateTime(2026, 3, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Career Night" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
