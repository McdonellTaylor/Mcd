using Microsoft.AspNetCore.Mvc;
using CUTDataScienceClub.Data;
using CUTDataScienceClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CUTDataScienceClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Project
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.ToListAsync();
            return View(projects);
        }

        // GET: Admin/Project/Upsert/{id?}
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Project());
            }

            var project = await _context.Projects.FindAsync(id.Value);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: Admin/Project/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("Id,Title,Description,Owner,StartDate,EndDate,RepositoryUrl,Technologies,IsActive")] Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            if (project.Id == 0)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Project created successfully.";
                TempData["ToastType"] = "success";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Update(project);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Project updated successfully.";
                TempData["ToastType"] = "success";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Projects.AnyAsync(p => p.Id == project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id.Value);
            if (project == null) return NotFound();

            return View(project);
        }

        // GET: Admin/Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id.Value);
            if (project == null) return NotFound();

            return View(project);
        }

        // POST: Admin/Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Project deleted.";
                TempData["ToastType"] = "success";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
