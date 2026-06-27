using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CUTDataScienceClub.Migrations
{
    /// <inheritdoc />
    public partial class creatingProjectsTableAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepositoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technologies = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EndDate", "IsActive", "Owner", "RepositoryUrl", "StartDate", "Technologies", "Title" },
                values: new object[,]
                {
                    { 1, "A web portal for students to access resources and events.", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "DSC", "https://github.com/cut-dsc/student-portal", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core, EF Core, Bootstrap", "Student Portal" },
                    { 2, "Scripts and notebooks for common Kaggle tasks.", null, true, "Data Team", "https://github.com/cut-dsc/kaggle-prep", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python, Pandas, scikit-learn", "Kaggle Prep Toolkit" },
                    { 3, "Platform to match students with alumni mentors.", null, true, "Alumni Affairs", "https://github.com/cut-dsc/alumni-mentorship", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js, Express, React", "Alumni Mentorship" },
                    { 4, "Tool to schedule and manage club events.", new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Events Committee", "https://github.com/cut-dsc/event-scheduler", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core, FullCalendar", "Event Scheduler" },
                    { 5, "Collection of data visualizations built by members.", null, true, "Design Team", "https://github.com/cut-dsc/dataviz-gallery", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D3.js, JavaScript", "DataViz Gallery" },
                    { 6, "Shared repository for research projects and papers.", null, true, "Research Group", "https://github.com/cut-dsc/research-repo", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Markdown, LaTeX, Jupyter", "Research Repo" },
                    { 7, "Aggregates internship and job postings.", null, true, "Careers", "https://github.com/cut-dsc/job-board", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python, Scrapy, Elasticsearch", "Job Board Aggregator" },
                    { 8, "ML model to recommend mentors to mentees.", null, true, "AI Lab", "https://github.com/cut-dsc/mentor-ai", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python, TensorFlow, scikit-learn", "Mentor Matching AI" },
                    { 9, "Tool to help members create portfolios.", null, true, "Career Services", "https://github.com/cut-dsc/portfolio-builder", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React, Node.js", "Portfolio Builder" },
                    { 10, "Curated datasets with metadata for projects.", null, true, "Data Team", "https://github.com/cut-dsc/dataset-catalog", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postgres, Python", "Dataset Catalog" },
                    { 11, "An educational chatbot for tutorials and FAQs.", null, true, "Education", "https://github.com/cut-dsc/chatbot-tutor", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python, Rasa", "Chatbot Tutor" },
                    { 12, "Boilerplate code and templates for hackathons.", null, true, "Hackathon Team", "https://github.com/cut-dsc/hackathon-toolkit", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multiple", "Hackathon Toolkit" },
                    { 13, "Dashboard for club KPIs and metrics.", null, true, "Leadership", "https://github.com/cut-dsc/analytics-dashboard", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Power BI, SQL, ASP.NET Core", "Analytics Dashboard" },
                    { 14, "Helps members find study groups by subject.", null, true, "Community", "https://github.com/cut-dsc/study-groups", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "React, Firebase", "Study Group Finder" },
                    { 15, "Mobile companion app for club events and news.", null, true, "Mobile Team", "https://github.com/cut-dsc/mobile-app", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flutter", "Mobile App" },
                    { 16, "Track volunteer hours and roles.", null, true, "Outreach", "https://github.com/cut-dsc/volunteer-tracker", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core, EF Core", "Volunteer Tracker" },
                    { 17, "Manage sponsor information and proposals.", null, true, "Sponsorship", "https://github.com/cut-dsc/sponsorship-portal", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core", "Sponsorship Portal" },
                    { 18, "Series of writeups on club research projects.", null, true, "Research Group", "https://github.com/cut-dsc/paper-series", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Markdown, LaTeX", "Research Paper Series" },
                    { 19, "Improve accessibility across club web properties.", null, true, "Design Team", "https://github.com/cut-dsc/accessibility-audit", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML, CSS, JS", "Accessibility Audit" },
                    { 20, "Migrate older projects into the new monorepo.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Platform Team", "https://github.com/cut-dsc/legacy-migration", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bash, Git", "Legacy Migration" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
