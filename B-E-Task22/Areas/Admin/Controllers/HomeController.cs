using B_E_Task22.DAL;
using B_E_Task22.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_E_Task22.Areas.Admin.Models
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
          
        }
        public IActionResult Index()
        {
            return View( _db.RecentWorkCompononents.ToList());
        }

        public IActionResult Creat()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Creat(RecentWorkCompononent recent)
        {
            if(!ModelState.IsValid) return View(recent);
            _db.RecentWorkCompononents.Add(recent);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
