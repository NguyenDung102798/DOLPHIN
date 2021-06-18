using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOLPHIN.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DOLPHIN.DTO;

namespace DOLPHIN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly ApplicationDBContext _context;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public NewsController(ApplicationDBContext context, IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnviroment;
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.News.Include(n => n.CreatedBy).Include(n => n.UpdatedBy);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.CreatedBy)
                .Include(n => n.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(NewsDto news)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                var filePaths = new List<string>();
                // full path to file in temp location
                fileName = Guid.NewGuid().ToString() + "_" + news.Images.FileName;
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadFolder, fileName);
                filePaths.Add(filePath);
                news.Images.CopyTo(new FileStream(filePath, FileMode.Create));
                News newsArtical = new News
                {
                    CreatedById = news.CreatedById,
                    UpdatedById = news.UpdatedById,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Titile = news.Titile,
                    Description = news.Description,
                    Refer = news.Refer,
                    Images = fileName
                };
                _context.Add(newsArtical);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/News/Index");
            }
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Email", news.CreatedById);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Email", news.UpdatedById);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titile,Images,Description,Refer,UpdatedDate,UpdatedById,CreatedDate,CreatedById")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Email", news.CreatedById);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Email", news.UpdatedById);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.CreatedBy)
                .Include(n => n.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
