﻿using B_E_Task22.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_E_Task22.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.RecentWorkCompononents.Take(3).ToList());
        }
        public IActionResult LoadMore(int skipRow)
        {
            return PartialView("LoadMore",_db.RecentWorkCompononents.Skip(3 * skipRow).Take(3).ToList());
        }
    }
}
