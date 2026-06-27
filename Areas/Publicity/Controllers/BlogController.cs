using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CUTDataScienceClub.Models;
using CUTDataScienceClub.Data;

namespace CUTDataScienceClub.Areas.Publicity.Controllers
{
    [Area("Publicity")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /Publicity/Blog
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.OrderByDescending(b => b.PublishedDate).ToListAsync();
            return View(blogs);
        }

        // GET: /Publicity/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id.Value);
            if (blog == null) return NotFound();

            return View(blog);
        }

        // Note: Create actions removed — Upsert handles both create and update.

        // GET: /Publicity/Blog/Upsert/5  (id optional)
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null) return View(new Blog());

            var blog = await _context.Blogs.FindAsync(id.Value);
            if (blog == null) return NotFound();
            return View(blog);
        }

        // POST: /Publicity/Blog/Upsert/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(int id, Blog blog)
        {
            if (id != 0 && id != blog.Id) return BadRequest();

            if (!ModelState.IsValid) return View(blog);

            if (blog.Id == 0)
            {
                // new: handle image and video uploads
                var imgResult = await HandleImageUploadAsync(blog);
                if (!imgResult.IsValid)
                {
                    ModelState.AddModelError("ImageUpload", imgResult.Error ?? "Invalid image upload.");
                    return View(blog);
                }

                var uploadResult = await HandleVideoUploadAsync(blog);
                if (!uploadResult.IsValid)
                {
                    ModelState.AddModelError("VideoUpload", uploadResult.Error ?? "Invalid video upload.");
                    return View(blog);
                }

                _context.Blogs.Add(blog);
                TempData["ToastMessage"] = "Blog created successfully.";
                TempData["ToastType"] = "success";
            }
            else
            {
                var existing = await _context.Blogs.FindAsync(blog.Id);
                if (existing == null) return NotFound();

                // update scalar properties
                existing.Title = blog.Title;
                existing.Slug = blog.Slug;
                existing.Excerpt = blog.Excerpt;
                existing.Content = blog.Content;
                existing.Author = blog.Author;
                existing.PublishedDate = blog.PublishedDate;
                existing.IsPublished = blog.IsPublished;
                existing.ImageUrl = blog.ImageUrl;
                existing.Tags = blog.Tags;

                // handle video upload (replace if new file provided)
                if (blog.VideoUpload != null)
                {
                    var uploadResult = await HandleVideoUploadAsync(blog);
                    if (!uploadResult.IsValid)
                    {
                        ModelState.AddModelError("VideoUpload", uploadResult.Error ?? "Invalid video upload.");
                        return View(blog);
                    }

                    // delete old file after successful upload
                    if (!string.IsNullOrEmpty(existing.VideoFileName))
                    {
                        var oldPath = Path.Combine(_env.WebRootPath, "uploads", "videos", existing.VideoFileName);
                        if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                    }

                    existing.VideoFileName = blog.VideoFileName;
                    existing.VideoUrl = blog.VideoUrl;
                }

                // handle image upload (replace if new file provided)
                if (blog.ImageUpload != null)
                {
                    var imgResult = await HandleImageUploadAsync(blog);
                    if (!imgResult.IsValid)
                    {
                        ModelState.AddModelError("ImageUpload", imgResult.Error ?? "Invalid image upload.");
                        return View(blog);
                    }

                    // delete old image file if it was stored in uploads/images
                    if (!string.IsNullOrEmpty(existing.ImageUrl) && existing.ImageUrl.StartsWith("/uploads/images/"))
                    {
                        var oldPath = Path.Combine(_env.WebRootPath, existing.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                    }

                    existing.ImageUrl = blog.ImageUrl;
                }

                TempData["ToastMessage"] = "Blog updated successfully.";
                TempData["ToastType"] = "success";

                _context.Blogs.Update(existing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Publicity/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var blog = await _context.Blogs.FindAsync(id.Value);
            if (blog == null) return NotFound();
            return View(blog);
        }

        // POST: /Publicity/Blog/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            // delete video file if exists
            if (!string.IsNullOrEmpty(blog.VideoFileName))
            {
                var path = Path.Combine(_env.WebRootPath, "uploads", "videos", blog.VideoFileName);
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            TempData["ToastMessage"] = "Blog deleted.";
            TempData["ToastType"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // Helper: save uploaded video to wwwroot/uploads/videos and set Blog.VideoFileName/VideoUrl
        private async Task<(bool IsValid, string? Error)> HandleVideoUploadAsync(Blog blog)
        {
            if (blog.VideoUpload == null || blog.VideoUpload.Length == 0) return (true, null);

            // Server-side validation
            var allowedContentTypes = new[] { "video/mp4", "video/webm", "video/quicktime", "video/x-matroska" };
            var allowedExtensions = new[] { ".mp4", ".webm", ".mov", ".mkv" };
            const long maxBytes = 50 * 1024 * 1024; // 50 MB

            if (blog.VideoUpload.Length > maxBytes)
            {
                return (false, $"Video must be smaller than {maxBytes / (1024 * 1024)} MB.");
            }

            if (!allowedContentTypes.Contains(blog.VideoUpload.ContentType))
            {
                return (false, "Unsupported video type. Allowed types: MP4, WebM, MOV, MKV.");
            }

            var ext = Path.GetExtension(blog.VideoUpload.FileName)?.ToLowerInvariant() ?? string.Empty;
            if (!allowedExtensions.Contains(ext))
            {
                return (false, "Unsupported video file extension.");
            }

            var uploadsRoot = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", "videos");
            Directory.CreateDirectory(uploadsRoot);

            var safeName = System.Guid.NewGuid().ToString() + ext;
            var filePath = Path.Combine(uploadsRoot, safeName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await blog.VideoUpload.CopyToAsync(stream);
            }

            blog.VideoFileName = safeName;
            blog.VideoUrl = $"/uploads/videos/{safeName}";
            return (true, null);
        }

        // Helper: save uploaded image to wwwroot/uploads/images and set Blog.ImageUrl
        private async Task<(bool IsValid, string? Error)> HandleImageUploadAsync(Blog blog)
        {
            if (blog.ImageUpload == null || blog.ImageUpload.Length == 0) return (true, null);

            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            const long maxBytes = 10 * 1024 * 1024; // 10 MB

            if (blog.ImageUpload.Length > maxBytes)
            {
                return (false, $"Image must be smaller than {maxBytes / (1024 * 1024)} MB.");
            }

            if (!allowedContentTypes.Contains(blog.ImageUpload.ContentType))
            {
                return (false, "Unsupported image type. Allowed types: JPG, PNG, GIF.");
            }

            var ext = Path.GetExtension(blog.ImageUpload.FileName)?.ToLowerInvariant() ?? string.Empty;
            if (!allowedExtensions.Contains(ext))
            {
                return (false, "Unsupported image file extension.");
            }

            var uploadsRoot = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", "images");
            Directory.CreateDirectory(uploadsRoot);

            var safeName = System.Guid.NewGuid().ToString() + ext;
            var filePath = Path.Combine(uploadsRoot, safeName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await blog.ImageUpload.CopyToAsync(stream);
            }

            blog.ImageUrl = $"/uploads/images/{safeName}";
            return (true, null);
        }
    }
}
