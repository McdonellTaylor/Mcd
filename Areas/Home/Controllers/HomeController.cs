using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CUTDataScienceClub.Models;
using System.Collections.Generic;
using CUTDataScienceClub.Data;
using Microsoft.EntityFrameworkCore;

namespace CUTDataScienceClub.Areas.Home.Controllers;

[Area("Home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new CUTDataScienceClub.ViewModels.HomeViewModel();

        vm.Members = await _db.Members.OrderBy(m => m.FullName).Take(12).ToListAsync();
        vm.Events = await _db.Events.Where(e => e.IsPublished).OrderBy(e => e.StartDate).Take(6).ToListAsync();
        vm.Projects = await _db.Projects.OrderByDescending(p => p.StartDate).Take(8).ToListAsync();
        vm.Blogs = await _db.Blogs.Where(b => b.IsPublished).OrderByDescending(b => b.PublishedDate).Take(6).ToListAsync();
        vm.ClubInformations = await _db.ClubInformations.Take(1).ToListAsync();
        vm.ClubInformation = vm.ClubInformations.FirstOrDefault();

        return View(vm);
    }

    // Custom pages (View All) for Home area — separate from Admin/Publicity controllers
    public async Task<IActionResult> ProjectsAll()
    {
        var vm = new CUTDataScienceClub.ViewModels.HomeViewModel();
        vm.Projects = await _db.Projects.OrderByDescending(p => p.StartDate).ToListAsync();
        return View(vm);
    }

    public async Task<IActionResult> BlogsAll()
    {
        var vm = new CUTDataScienceClub.ViewModels.HomeViewModel();
        vm.Blogs = await _db.Blogs.OrderByDescending(b => b.PublishedDate).ToListAsync();
        return View(vm);
    }

    public async Task<IActionResult> MembersAll()
    {
        var vm = new CUTDataScienceClub.ViewModels.HomeViewModel();
        vm.Members = await _db.Members.OrderBy(m => m.FullName).ToListAsync();
        return View(vm);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // Return published blogs to a view. We render the existing Publicity Blog Index view
    // so we don't duplicate markup; pass the blog list as the model.
    public async Task<IActionResult> Blogs()
    {
        IEnumerable<Blog> blogs = await _db.Blogs
            .Where(b => b.IsPublished)
            .OrderByDescending(b => b.PublishedDate)
            .ToListAsync();

        return View(blogs);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
