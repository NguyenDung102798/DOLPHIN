using DOLPHIN.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOLPHIN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OptionController : Controller
    {
        private readonly ApplicationDBContext _context;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public OptionController(ApplicationDBContext context, IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnviroment;
        }
        public IActionResult Index()
        {
            var option = this._context.Options.ToList();
            return View(option);
        }

        // Mothod: Get
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Option/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Options options)
        {
            if (ModelState.IsValid)
            {
                _context.Add(options);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Option/Index");
            }
            return View(options);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
