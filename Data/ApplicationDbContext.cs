using System;
using CUTDataScienceClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace CUTDataScienceClub.Data
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
                public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
                {
                }

                public DbSet<Member> Members { get; set; }
                public DbSet<Event> Events { get; set; }
                public DbSet<Project> Projects { get; set; }
                public DbSet<Blog> Blogs { get; set; }
                public DbSet<ClubInformation> ClubInformations { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        base.OnModelCreating(modelBuilder);

                        // Seed Identity roles deterministically so they become part of EF migrations
                        // Use stable GUIDs so the seeded records are consistent across environments
                        modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().HasData(
                                new Microsoft.AspNetCore.Identity.IdentityRole { Id = "a1b2c3d4-0000-0000-0000-000000000001", Name = "Admin", NormalizedName = "ADMIN" },
                                new Microsoft.AspNetCore.Identity.IdentityRole { Id = "a1b2c3d4-0000-0000-0000-000000000002", Name = "User", NormalizedName = "USER" },
                                new Microsoft.AspNetCore.Identity.IdentityRole { Id = "a1b2c3d4-0000-0000-0000-000000000003", Name = "PublicityManager", NormalizedName = "PUBLICITYMANAGER" }
                        );

                        modelBuilder.Entity<Member>().HasData(
                                new Member { Id = 1, FullName = "Alice Johnson", RegNumber = "DSC001", Program = "Data Science", CurrentLevel = "100" },
                                new Member { Id = 2, FullName = "Bob Smith", RegNumber = "DSC002", Program = "Data Science", CurrentLevel = "200" },
                                new Member { Id = 3, FullName = "Carol Lee", RegNumber = "DSC003", Program = "Statistics", CurrentLevel = "300" },
                                new Member { Id = 4, FullName = "David Kim", RegNumber = "DSC004", Program = "Computer Science", CurrentLevel = "400" },
                                new Member { Id = 5, FullName = "Eva Brown", RegNumber = "DSC005", Program = "Data Science", CurrentLevel = "200" },
                                new Member { Id = 6, FullName = "Frank White", RegNumber = "DSC006", Program = "Mathematics", CurrentLevel = "100" },
                                new Member { Id = 7, FullName = "Grace Green", RegNumber = "DSC007", Program = "Data Science", CurrentLevel = "300" },
                                new Member { Id = 8, FullName = "Henry Black", RegNumber = "DSC008", Program = "Statistics", CurrentLevel = "400" },
                                new Member { Id = 9, FullName = "Ivy Blue", RegNumber = "DSC009", Program = "Computer Science", CurrentLevel = "200" },
                                new Member { Id = 10, FullName = "Jack Red", RegNumber = "DSC010", Program = "Mathematics", CurrentLevel = "100" }
                        );

                        modelBuilder.Entity<Event>().HasData(
                                new Event { Id = 1, Title = "Intro to Data Science", Description = "A beginner-friendly intro to data science concepts.", Location = "Room A1", StartDate = new DateTime(2025, 11, 01, 10, 0, 0), EndDate = new DateTime(2025, 11, 01, 12, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 2, Title = "Python for Analysis", Description = "Hands-on session on using Python for data analysis.", Location = "Lab 2", StartDate = new DateTime(2025, 11, 08, 14, 0, 0), EndDate = new DateTime(2025, 11, 08, 16, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 3, Title = "Statistics Workshop", Description = "Probability and statistics refresher.", Location = "Room B3", StartDate = new DateTime(2025, 11, 15, 9, 0, 0), EndDate = new DateTime(2025, 11, 15, 11, 0, 0), Organizer = "Math Dept", IsPublished = true },
                                new Event { Id = 4, Title = "Machine Learning 101", Description = "Overview of supervised and unsupervised learning.", Location = "Auditorium", StartDate = new DateTime(2025, 11, 22, 13, 0, 0), EndDate = new DateTime(2025, 11, 22, 15, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 5, Title = "Data Viz with Tableau", Description = "Create compelling visuals with Tableau.", Location = "Lab 1", StartDate = new DateTime(2025, 12, 01, 10, 0, 0), EndDate = new DateTime(2025, 12, 01, 12, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 6, Title = "R for Data Science", Description = "Intro to R and tidyverse.", Location = "Room C2", StartDate = new DateTime(2025, 12, 06, 14, 0, 0), EndDate = new DateTime(2025, 12, 06, 16, 0, 0), Organizer = "Stats Club", IsPublished = true },
                                new Event { Id = 7, Title = "Big Data Architectures", Description = "Talk on scalable data systems.", Location = "Conference Hall", StartDate = new DateTime(2025, 12, 12, 9, 30, 0), EndDate = new DateTime(2025, 12, 12, 11, 30, 0), Organizer = "CS Dept", IsPublished = true },
                                new Event { Id = 8, Title = "NLP Basics", Description = "Natural Language Processing primer.", Location = "Room D1", StartDate = new DateTime(2026, 01, 10, 10, 0, 0), EndDate = new DateTime(2026, 01, 10, 12, 0, 0), Organizer = "AI Group", IsPublished = true },
                                new Event { Id = 9, Title = "Kaggle Competition Prep", Description = "How to approach Kaggle problems.", Location = "Lab 3", StartDate = new DateTime(2026, 01, 17, 14, 0, 0), EndDate = new DateTime(2026, 01, 17, 16, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 10, Title = "Ethics in AI", Description = "Panel on ethical considerations in AI.", Location = "Auditorium", StartDate = new DateTime(2026, 01, 24, 13, 0, 0), EndDate = new DateTime(2026, 01, 24, 15, 0, 0), Organizer = "Philosophy Dept", IsPublished = true },
                                new Event { Id = 11, Title = "Data Engineering Bootcamp", Description = "Two-day bootcamp on ETL and pipelines.", Location = "Workshop Room", StartDate = new DateTime(2026, 02, 05, 9, 0, 0), EndDate = new DateTime(2026, 02, 06, 17, 0, 0), Organizer = "DSC", IsPublished = true },
                                new Event { Id = 12, Title = "Time Series Analysis", Description = "Analyzing temporal data with ARIMA and more.", Location = "Room B2", StartDate = new DateTime(2026, 02, 14, 10, 0, 0), EndDate = new DateTime(2026, 02, 14, 12, 0, 0), Organizer = "Stats Club", IsPublished = true },
                                new Event { Id = 13, Title = "Data Storytelling", Description = "Techniques for communicating results.", Location = "Room A2", StartDate = new DateTime(2026, 02, 21, 11, 0, 0), EndDate = new DateTime(2026, 02, 21, 13, 0, 0), Organizer = "Communications", IsPublished = true },
                                new Event { Id = 14, Title = "Deep Learning Workshop", Description = "Intro to deep neural networks.", Location = "Lab 4", StartDate = new DateTime(2026, 03, 03, 9, 0, 0), EndDate = new DateTime(2026, 03, 03, 17, 0, 0), Organizer = "AI Group", IsPublished = true },
                                new Event { Id = 15, Title = "Career Night", Description = "Meet industry recruiters and alumni.", Location = "Conference Hall", StartDate = new DateTime(2026, 03, 12, 17, 0, 0), EndDate = new DateTime(2026, 03, 12, 20, 0, 0), Organizer = "DSC", IsPublished = true }
                        );

                        modelBuilder.Entity<Project>().HasData(
                                new Project { Id = 1, Title = "Student Portal", Description = "A web portal for students to access resources and events.", Owner = "DSC", StartDate = new DateTime(2024, 09, 01), EndDate = new DateTime(2025, 06, 30), RepositoryUrl = "https://github.com/cut-dsc/student-portal", Technologies = "ASP.NET Core, EF Core, Bootstrap", IsActive = true },
                                new Project { Id = 2, Title = "Kaggle Prep Toolkit", Description = "Scripts and notebooks for common Kaggle tasks.", Owner = "Data Team", StartDate = new DateTime(2024, 10, 15), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/kaggle-prep", Technologies = "Python, Pandas, scikit-learn", IsActive = true },
                                new Project { Id = 3, Title = "Alumni Mentorship", Description = "Platform to match students with alumni mentors.", Owner = "Alumni Affairs", StartDate = new DateTime(2025, 01, 05), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/alumni-mentorship", Technologies = "Node.js, Express, React", IsActive = true },
                                new Project { Id = 4, Title = "Event Scheduler", Description = "Tool to schedule and manage club events.", Owner = "Events Committee", StartDate = new DateTime(2024, 11, 01), EndDate = new DateTime(2025, 03, 31), RepositoryUrl = "https://github.com/cut-dsc/event-scheduler", Technologies = "ASP.NET Core, FullCalendar", IsActive = true },
                                new Project { Id = 5, Title = "DataViz Gallery", Description = "Collection of data visualizations built by members.", Owner = "Design Team", StartDate = new DateTime(2024, 08, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/dataviz-gallery", Technologies = "D3.js, JavaScript", IsActive = true },
                                new Project { Id = 6, Title = "Research Repo", Description = "Shared repository for research projects and papers.", Owner = "Research Group", StartDate = new DateTime(2024, 06, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/research-repo", Technologies = "Markdown, LaTeX, Jupyter", IsActive = true },
                                new Project { Id = 7, Title = "Job Board Aggregator", Description = "Aggregates internship and job postings.", Owner = "Careers", StartDate = new DateTime(2025, 02, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/job-board", Technologies = "Python, Scrapy, Elasticsearch", IsActive = true },
                                new Project { Id = 8, Title = "Mentor Matching AI", Description = "ML model to recommend mentors to mentees.", Owner = "AI Lab", StartDate = new DateTime(2025, 03, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/mentor-ai", Technologies = "Python, TensorFlow, scikit-learn", IsActive = true },
                                new Project { Id = 9, Title = "Portfolio Builder", Description = "Tool to help members create portfolios.", Owner = "Career Services", StartDate = new DateTime(2024, 12, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/portfolio-builder", Technologies = "React, Node.js", IsActive = true },
                                new Project { Id = 10, Title = "Dataset Catalog", Description = "Curated datasets with metadata for projects.", Owner = "Data Team", StartDate = new DateTime(2024, 05, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/dataset-catalog", Technologies = "Postgres, Python", IsActive = true },
                                new Project { Id = 11, Title = "Chatbot Tutor", Description = "An educational chatbot for tutorials and FAQs.", Owner = "Education", StartDate = new DateTime(2025, 04, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/chatbot-tutor", Technologies = "Python, Rasa", IsActive = true },
                                new Project { Id = 12, Title = "Hackathon Toolkit", Description = "Boilerplate code and templates for hackathons.", Owner = "Hackathon Team", StartDate = new DateTime(2024, 09, 20), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/hackathon-toolkit", Technologies = "Multiple", IsActive = true },
                                new Project { Id = 13, Title = "Analytics Dashboard", Description = "Dashboard for club KPIs and metrics.", Owner = "Leadership", StartDate = new DateTime(2024, 07, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/analytics-dashboard", Technologies = "Power BI, SQL, ASP.NET Core", IsActive = true },
                                new Project { Id = 14, Title = "Study Group Finder", Description = "Helps members find study groups by subject.", Owner = "Community", StartDate = new DateTime(2025, 01, 10), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/study-groups", Technologies = "React, Firebase", IsActive = true },
                                new Project { Id = 15, Title = "Mobile App", Description = "Mobile companion app for club events and news.", Owner = "Mobile Team", StartDate = new DateTime(2025, 02, 15), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/mobile-app", Technologies = "Flutter", IsActive = true },
                                new Project { Id = 16, Title = "Volunteer Tracker", Description = "Track volunteer hours and roles.", Owner = "Outreach", StartDate = new DateTime(2024, 10, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/volunteer-tracker", Technologies = "ASP.NET Core, EF Core", IsActive = true },
                                new Project { Id = 17, Title = "Sponsorship Portal", Description = "Manage sponsor information and proposals.", Owner = "Sponsorship", StartDate = new DateTime(2024, 11, 15), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/sponsorship-portal", Technologies = "ASP.NET Core", IsActive = true },
                                new Project { Id = 18, Title = "Research Paper Series", Description = "Series of writeups on club research projects.", Owner = "Research Group", StartDate = new DateTime(2024, 04, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/paper-series", Technologies = "Markdown, LaTeX", IsActive = true },
                                new Project { Id = 19, Title = "Accessibility Audit", Description = "Improve accessibility across club web properties.", Owner = "Design Team", StartDate = new DateTime(2025, 05, 01), EndDate = null, RepositoryUrl = "https://github.com/cut-dsc/accessibility-audit", Technologies = "HTML, CSS, JS", IsActive = true },
                                new Project { Id = 20, Title = "Legacy Migration", Description = "Migrate older projects into the new monorepo.", Owner = "Platform Team", StartDate = new DateTime(2024, 03, 01), EndDate = new DateTime(2024, 12, 31), RepositoryUrl = "https://github.com/cut-dsc/legacy-migration", Technologies = "Bash, Git", IsActive = false }
                        );

                        modelBuilder.Entity<Blog>().HasData(
                                new Blog { Id = 1, Title = "Welcome to the CUT DSC Blog", Slug = "welcome-cut-dsc", Excerpt = "News and updates from the CUT Data Science Club.", Content = "This is the official blog of the CUT Data Science Club. We'll post event recaps, project highlights, tutorials and more.", Author = "DSC Team", PublishedDate = new DateTime(2025, 09, 01), IsPublished = true, ImageUrl = "https://example.com/images/blog1.jpg", Tags = "news,updates", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 2, Title = "Intro to Python for Data Science", Slug = "intro-python-data-science", Excerpt = "A short guide to getting started with Python.", Content = "Python is the most popular language for data science. In this post we cover installing Python, packages and basic data manipulation.", Author = "Alice Johnson", PublishedDate = new DateTime(2025, 09, 10), IsPublished = true, ImageUrl = "https://example.com/images/blog2.jpg", Tags = "python,tutorial", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 3, Title = "Kaggle Competition Tips", Slug = "kaggle-competition-tips", Excerpt = "Practical tips for competing on Kaggle.", Content = "From CV to feature engineering, these tips will help you improve your leaderboard position.", Author = "Bob Smith", PublishedDate = new DateTime(2025, 09, 20), IsPublished = true, ImageUrl = "https://example.com/images/blog3.jpg", Tags = "kaggle,competition", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 4, Title = "Event Recap: Machine Learning 101", Slug = "event-recap-ml-101", Excerpt = "Summary and key takeaways from our ML 101 workshop.", Content = "We covered supervised and unsupervised methods, with hands-on examples. Slides and notebooks are linked.", Author = "DSC Events", PublishedDate = new DateTime(2025, 11, 23), IsPublished = true, ImageUrl = "https://example.com/images/blog4.jpg", Tags = "events,ml", VideoUrl = "https://youtu.be/example1", VideoFileName = "ml101.mp4" },
                                new Blog { Id = 5, Title = "Data Visualization Best Practices", Slug = "data-viz-best-practices", Excerpt = "Guidelines for creating clear and effective visuals.", Content = "Choose the right chart, use color carefully, and make your story clear.", Author = "Carol Lee", PublishedDate = new DateTime(2025, 10, 05), IsPublished = true, ImageUrl = "https://example.com/images/blog5.jpg", Tags = "dataviz,design", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 6, Title = "Using SQL for Data Analysis", Slug = "using-sql-data-analysis", Excerpt = "SQL queries you should know for analysis.", Content = "Window functions, joins and aggregations are powerful tools for analysts.", Author = "David Kim", PublishedDate = new DateTime(2025, 10, 12), IsPublished = true, ImageUrl = "https://example.com/images/blog6.jpg", Tags = "sql,database", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 7, Title = "Member Spotlight: Eva Brown", Slug = "member-spotlight-eva-brown", Excerpt = "Interview with a standout member.", Content = "Eva shares her journey into data science and her recent projects.", Author = "DSC Team", PublishedDate = new DateTime(2025, 10, 18), IsPublished = true, ImageUrl = "https://example.com/images/blog7.jpg", Tags = "members,interview", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 8, Title = "Deep Learning Resources", Slug = "deep-learning-resources", Excerpt = "Curated list of courses and books to learn deep learning.", Content = "Here are recommended courses, books and project ideas to get started with deep learning.", Author = "AI Group", PublishedDate = new DateTime(2025, 08, 30), IsPublished = true, ImageUrl = "https://example.com/images/blog8.jpg", Tags = "deeplearning,resources", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 9, Title = "Getting Started with R", Slug = "getting-started-with-r", Excerpt = "Why use R and how to begin.", Content = "R remains a great language for statistics and data analysis; this post shows starter packages and workflows.", Author = "Frank White", PublishedDate = new DateTime(2025, 09, 25), IsPublished = true, ImageUrl = "https://example.com/images/blog9.jpg", Tags = "r,statistics", VideoUrl = null, VideoFileName = null },
                                new Blog { Id = 10, Title = "Project Showcase: DataViz Gallery", Slug = "project-showcase-dataviz-gallery", Excerpt = "Highlights from the DataViz Gallery project.", Content = "A collection of member-created visualizations showcasing different datasets and techniques.", Author = "Design Team", PublishedDate = new DateTime(2025, 10, 01), IsPublished = true, ImageUrl = "https://example.com/images/blog10.jpg", Tags = "projects,dataviz", VideoUrl = null, VideoFileName = null }
                        );

                        modelBuilder.Entity<ClubInformation>().HasData(
                                new ClubInformation
                                {
                                        Id = 1,
                                        Name = "CUT Data Science Club",
                                        ShortDescription = "Campus club for data science enthusiasts",
                                        About = "CUT Data Science Club (CUT DSC) brings together students interested in data science for workshops, projects and community events.",
                                        Mission = "Foster data literacy and practical skills through workshops and projects.",
                                        Vision = "Be the leading student data science community on campus.",
                                        ContactPerson = "Club President",
                                        Email = "contact@cutdsc.example",
                                        Phone = "+1234567890",
                                        Address = "Campus Main Hall",
                                        WebsiteUrl = "https://cutdsc.example.com",
                                        FoundedDate = new DateTime(2020, 1, 1),
                                        PrimaryColor = "#7c3aed",
                                        SecondaryColor = "#3b82f6"
                                }
                        );
                }
        }
}
