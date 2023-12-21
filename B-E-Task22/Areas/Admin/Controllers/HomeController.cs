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
            if (_db.RecentWorkCompononents.Any(r => r.Title == recent.Title))
            {
                ModelState.AddModelError("Title", "Eyni adan istifade Olunub");
                return View(recent);
            }
            _db.RecentWorkCompononents.Add(recent);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model =await _db.RecentWorkCompononents.FindAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model =await _db.RecentWorkCompononents.FindAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, RecentWorkCompononent recent)
        {
           
            if (!ModelState.IsValid) return View(recent);
            if(_db.RecentWorkCompononents.Any(r=>r.Title == recent.Title && r.Id != recent.Id))
            {
                ModelState.AddModelError("Title", "Eyni adan istifade Olunub");
                return View(recent);
            }
            if (id != recent.Id) return BadRequest();
            var dbRecent = await _db.RecentWorkCompononents.FindAsync(id);
            if(dbRecent == null) return NotFound();
            dbRecent.Title = recent.Title;
            dbRecent.Description= recent.Description;
            dbRecent.Image= recent.Image;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dbRecent = await _db.RecentWorkCompononents.FindAsync(id);
            if (dbRecent == null) return NotFound();
            _db.RecentWorkCompononents.Remove(dbRecent);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
