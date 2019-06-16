using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public LocationsController(ApplicationDbContext context,
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


        // GET: Locations
        public async Task<ActionResult> Index()

        {
            var applicationDbContext = _context.Locations
                .Include(p => p.State)
                .Include(p => p.County)
                .OrderBy(l => l.State.StateShort)
                .ThenBy(l => l.County.CountyName)
                .ThenBy(l => l.LocationCity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "CountyName");
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("LocationCity, LocationDetail, CountyId, StateId")]Locations location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(location);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
                ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "CountyName");
                return View(location);
            }
            catch
            {
                return View();
            }
        }

        // GET: Locations/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "CountyName");
            return View(location);
        }

        // POST: Locations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId, LocationCity, LocationDetail, StateId, CountyId ")]Locations location)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationId))
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
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "CountyName");
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var location = await _context.Locations
                .Include(p => p.State)
                .Include(p => p.County)
                .FirstOrDefaultAsync(l => l.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var location = await _context.Locations.FindAsync(id);
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}