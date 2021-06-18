using DOLPHIN.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOLPHIN.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly ApplicationDBContext _context;
        public NewsController(ILogger<NewsController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var article = _context.News.FirstOrDefault();
            ViewBag.NewArticle = _context.News.Skip(1).Take(3).ToList();

            return View(article);
        }
    }
}
