using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CUTDataScienceClub.Migrations
{
    /// <inheritdoc />
    public partial class addBlogsTableAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Excerpt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    VideoFileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "Content", "Excerpt", "ImageUrl", "IsPublished", "PublishedDate", "Slug", "Tags", "Title", "VideoFileName", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "DSC Team", "This is the official blog of the CUT Data Science Club. We'll post event recaps, project highlights, tutorials and more.", "News and updates from the CUT Data Science Club.", "https://example.com/images/blog1.jpg", true, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "welcome-cut-dsc", "news,updates", "Welcome to the CUT DSC Blog", null, null },
                    { 2, "Alice Johnson", "Python is the most popular language for data science. In this post we cover installing Python, packages and basic data manipulation.", "A short guide to getting started with Python.", "https://example.com/images/blog2.jpg", true, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "intro-python-data-science", "python,tutorial", "Intro to Python for Data Science", null, null },
                    { 3, "Bob Smith", "From CV to feature engineering, these tips will help you improve your leaderboard position.", "Practical tips for competing on Kaggle.", "https://example.com/images/blog3.jpg", true, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaggle-competition-tips", "kaggle,competition", "Kaggle Competition Tips", null, null },
                    { 4, "DSC Events", "We covered supervised and unsupervised methods, with hands-on examples. Slides and notebooks are linked.", "Summary and key takeaways from our ML 101 workshop.", "https://example.com/images/blog4.jpg", true, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "event-recap-ml-101", "events,ml", "Event Recap: Machine Learning 101", "ml101.mp4", "https://youtu.be/example1" },
                    { 5, "Carol Lee", "Choose the right chart, use color carefully, and make your story clear.", "Guidelines for creating clear and effective visuals.", "https://example.com/images/blog5.jpg", true, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "data-viz-best-practices", "dataviz,design", "Data Visualization Best Practices", null, null },
                    { 6, "David Kim", "Window functions, joins and aggregations are powerful tools for analysts.", "SQL queries you should know for analysis.", "https://example.com/images/blog6.jpg", true, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "using-sql-data-analysis", "sql,database", "Using SQL for Data Analysis", null, null },
                    { 7, "DSC Team", "Eva shares her journey into data science and her recent projects.", "Interview with a standout member.", "https://example.com/images/blog7.jpg", true, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "member-spotlight-eva-brown", "members,interview", "Member Spotlight: Eva Brown", null, null },
                    { 8, "AI Group", "Here are recommended courses, books and project ideas to get started with deep learning.", "Curated list of courses and books to learn deep learning.", "https://example.com/images/blog8.jpg", true, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "deep-learning-resources", "deeplearning,resources", "Deep Learning Resources", null, null },
                    { 9, "Frank White", "R remains a great language for statistics and data analysis; this post shows starter packages and workflows.", "Why use R and how to begin.", "https://example.com/images/blog9.jpg", true, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "getting-started-with-r", "r,statistics", "Getting Started with R", null, null },
                    { 10, "Design Team", "A collection of member-created visualizations showcasing different datasets and techniques.", "Highlights from the DataViz Gallery project.", "https://example.com/images/blog10.jpg", true, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "project-showcase-dataviz-gallery", "projects,dataviz", "Project Showcase: DataViz Gallery", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
