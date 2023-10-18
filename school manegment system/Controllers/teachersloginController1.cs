using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_manegment_system.Models;
using Microsoft.AspNetCore.Http; // Add this namespace
using Microsoft.AspNetCore.Authentication;
using school_manegment_system.datacontext;

namespace leacherslogin.Controllers
{
    public class teachersloginController : Controller
    {
        private readonly database _context;
        private object _contaxt;

        public teachersloginController(database context)
        {
            _context = context;
        }

        // GET: Logins


        // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password")] teacherslogin login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(login);
        }

        public IActionResult Login()
        {


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(teacherslogin u)
        {
            var data = await _context.teacherslogins.Where(model => model.Name == u.Name && model.Password == u.Password).FirstOrDefaultAsync();
            if (data == null)
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                HttpContext.Session.SetString("user_id", data.Id.ToString());
                return RedirectToAction("Index", "schools","index");
            }


        }



        public IActionResult adminlogin()
        {


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> adminlogin(adminlogin u)
        {
            var data = await _context.adminlogin.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefaultAsync();
            if (data == null)
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                HttpContext.Session.SetString("admin_id", data.Id.ToString());
                return RedirectToAction("create", "teacherslogin", "create");
            }


        }


        public async Task<IActionResult> About()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user_id")))
            {
                return RedirectToAction(nameof(Login));

            }

            else
            {
                return View();
            }
        }




        private bool LoginExists(int id)
        {
            return (_context.teacherslogins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
