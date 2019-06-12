using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PERSTAT.Data;
using PERSTAT.Models;

namespace PERSTAT.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public PeopleController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.People
                .Include(p => p.Status)
                .Include(p => p.Organization)
                .Include(p => p.Assignments);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var person = await _context.People
                .Include(p => p.Status)
                .Include(p => p.Organization)
                .FirstAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Label");

            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}