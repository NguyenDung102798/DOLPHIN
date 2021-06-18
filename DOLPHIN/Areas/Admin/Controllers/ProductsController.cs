using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOLPHIN.Model;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DOLPHIN.DTO;

namespace DOLPHIN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDBContext _context;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public ProductsController(ApplicationDBContext context, IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnviroment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var productsList = await _context.Products.Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .Include(c => c.Categories)
                .ToListAsync();
            return View(productsList);
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Email");
            //ViewData["Category"] = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(ProductViewDto products)
        {
            Guid userId = new Guid("33e23a3f-973a-497f-aa92-5228b04057a3");
            string fileName = null;
            if (ModelState.IsValid)
            {
                var filePaths = new List<string>();
                // full path to file in temp location
                fileName = Guid.NewGuid().ToString() + "_" + products.Images.FileName;
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadFolder, fileName);
                filePaths.Add(filePath);
                products.Images.CopyTo(new FileStream(filePath, FileMode.Create));
               
                Products newProduct = new Products
                {
                    Id = Guid.NewGuid(),
                    CreatedById = userId,
                    UpdatedById = userId,
                    CreatedDate = DateTime.Now,
                    ProductName = products.ProductName,
                    CategoryId = products.CategoryId,
                    Price = products.Price,
                    Desciption = products.Desciption,
                    Status = products.Status,
                    Images = fileName
                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Products/Index");
            }
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Email", products.CreatedById);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Email", products.UpdatedById);
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CategoryId,ProductName,Price,Color,Size,Desciption,Status,UpdatedDate,UpdatedById,CreatedDate,CreatedById")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Email", products.CreatedById);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Email", products.UpdatedById);
            return View(products);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/Products/Index");
        }

        private bool ProductsExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
