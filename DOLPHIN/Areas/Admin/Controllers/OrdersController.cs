using DOLPHIN.Model;
using DOLPHIN.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOLPHIN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IAddressService addressService;

        public OrdersController(ApplicationDBContext context, IAddressService addressService)
        {
            _context = context;
            this.addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Orders.Include(c => c.CreatedBy).Include(c => c.UpdatedBy).Where(x => x.Id != null).OrderByDescending(x => x.CreatedDate);
            return View(await applicationDBContext.ToListAsync());
        }
        public async Task<IActionResult> Detail(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.Where(x => x.Id == Id).FirstOrDefault();
            var detailOrder = await this.addressService.OrderInfo(order.OrderCode);
            return View(detailOrder);
        }
    }
}
