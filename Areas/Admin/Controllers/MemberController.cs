using Microsoft.AspNetCore.Mvc;
using CUTDataScienceClub.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CUTDataScienceClub.Models;

namespace CUTDataScienceClub.Areas.Admin.Controllers;

[Area("Admin")]
public class MemberController : Controller
{

    private readonly ApplicationDbContext _context;
    public MemberController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Admin/Member
    public async Task<IActionResult> Index()
    {
        IEnumerable<Member> members = await _context.Members.ToListAsync();
        return View(members);
    }

    // GET: Admin/Member/Upsert/{id?}
    public async Task<IActionResult> Upsert(int? id)
    {
        if (id == null)
        {
            // Create
            return View(new Member());
        }

        var member = await _context.Members.FindAsync(id.Value);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    // POST: Admin/Member/Upsert
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert([Bind("Id,FullName,RegNumber,Program,CurrentLevel")] Member member)
    {
        if (!ModelState.IsValid)
        {
            return View(member);
        }

        if (member.Id == 0)
        {
            // Create
            _context.Add(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Update
        try
        {
            _context.Update(member);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Members.AnyAsync(e => e.Id == member.Id))
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

    // GET: Admin/Member/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id.Value);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    // GET: Admin/Member/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id.Value);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    // POST: Admin/Member/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}