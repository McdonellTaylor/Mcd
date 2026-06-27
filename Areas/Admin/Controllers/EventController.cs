using Microsoft.AspNetCore.Mvc;
using CUTDataScienceClub.Data;
using CUTDataScienceClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUTDataScienceClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Event
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // GET: Admin/Event/Upsert/{id?}
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Event());
            }

            var eventEntity = await _context.Events.FindAsync(id.Value);
            if (eventEntity == null)
            {
                return NotFound();
            }

            return View(eventEntity);
        }

        // POST: Admin/Event/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("Id,Title,Description,Location,StartDate,EndDate,Organizer,IsPublished")] Event eventEntity)
        {
            if (!ModelState.IsValid)
            {
                return View(eventEntity);
            }

            if (eventEntity.Id == 0)
            {
                _context.Add(eventEntity);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Event created successfully.";
                TempData["ToastType"] = "success";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Update(eventEntity);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Event updated successfully.";
                TempData["ToastType"] = "success";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Events.AnyAsync(e => e.Id == eventEntity.Id))
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

        // GET: Admin/Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id.Value);
            if (eventEntity == null) return NotFound();

            return View(eventEntity);
        }

        // GET: Admin/Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id.Value);
            if (eventEntity == null) return NotFound();

            return View(eventEntity);
        }

        // POST: Admin/Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity != null)
            {
                _context.Events.Remove(eventEntity);
                await _context.SaveChangesAsync();
                TempData["ToastMessage"] = "Event deleted.";
                TempData["ToastType"] = "success";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}