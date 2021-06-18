using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOLPHIN.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOLPHIN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(ApplicationDBContext context, IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnviroment;
        }
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/admin/login/");
            }
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalSales = (await _context.OrderDetails.Select(x => x.UnitPrice).ToListAsync()).Sum(x => Convert.ToInt32(x));
            return View();
            
        }
    }
}
