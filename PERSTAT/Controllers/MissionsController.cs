using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PERSTAT.Data;
using PERSTAT.Models;

namespace PERSTAT.Controllers
{
    public class MissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public MissionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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


        // GET: Missions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Missions
            .Include(m => m.Assignments);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Missions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Missions/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Missions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("MissionTitle, MissionDescription")]Missions mission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mission);
        }

        // GET: Missions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mission = await _context.Missions.FindAsync(id);
            if (mission== null)
            {
                return NotFound();
            }
            return View(mission);
            }

        // POST: Missions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, MissionTitle, MissionDescription")] Missions mission)
        {
            if(id != mission.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(mission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists(mission.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(mission);
        }

        // GET: Missions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Missions/Delete/5
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

        private bool MissionExists(int id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }
    }
}