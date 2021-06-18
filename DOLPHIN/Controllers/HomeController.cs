using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DOLPHIN.Models;
using DOLPHIN.Model;

namespace DOLPHIN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var listProductHot = _context.Products.Where(x => x.Categories.Name.Equals("Áo")).Take(16).ToList();
            ViewBag.ListProductNew = _context.Products.Where(x => x.Categories.Name.Equals("Váy")).Take(16).ToList();
            ViewBag.NewArticle = _context.News.Skip(1).Take(3).ToList();
            return View(listProductHot);
        }

        public IActionResult Details(Guid id)
        {
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            var products = _context.Products.Where(x => x.Id == id).ToList();
            // get reference of product 
            var categoryId = _context.Products.Where(x => x.Id == id).Select(c => c.Categories.Id).FirstOrDefault();
            ViewBag.Suggestions = _context.Products.Where(x => x.Categories.Id == categoryId).Take(4).ToList().Except(products);
            ViewBag.Size = _context.Options.Where(x => x.Color == "Trắng").Select(s => s.Size).ToList();
            ViewBag.Color = _context.Options.Where(x => x.Size == "L").Select(c => c.Color).ToList();
            return View(product);
        }
        public IActionResult Shop(string keyword)
        {
            var results = _context.Products.Where(p => string.IsNullOrEmpty(p.ProductName) == false &&
                                                    p.ProductName.ToLower().Contains(keyword))
                                                    .ToList();
            return View(results);
        }
        public IActionResult Sales()
        {
            var results = _context.Products.Where(p => p.Status == 1).ToList();
            return View(results);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Infomation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
