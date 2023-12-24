using B_E_Task22.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_E_Task22.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _db;

        public PricingController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Pricings.Take(3).ToList());
        }
        public IActionResult LoadMore(int skipRow)
        {
            return PartialView("_PricingPartialView", _db.Pricings.Skip(3 * skipRow).Take(3).ToList());
        }
    }
}
