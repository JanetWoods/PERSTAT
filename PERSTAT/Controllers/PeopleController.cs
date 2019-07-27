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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.People
                .Include(p => p.Status)
                .Include(p => p.Organization)
                .Include(p => p.Organization.State)
                .Include(p => p.Assignments)
                .OrderBy(p => p.NameLast)
                .ThenBy(p => p.NameFirst);
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
                .Include(p => p.Organization.State)
                .FirstAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // GET: People/Create
        [Authorize]
        public IActionResult Create()
        {
            var detailedOrg = _context.Organization.OrderBy(o => o.OrganizationName).ThenBy(o => o.State.StateShort)
                .Include(p => p.State).Select(s => new
                {
                    OrganizationId = s.OrganizationId,
                    StateShort = s.OrganizationName + " - " + s.State.StateShort
                }).ToList();

            var betterStatus = _context.Status.OrderBy(s => s.StatusName);

            ViewData["OrganizationId"] = new SelectList(detailedOrg, "OrganizationId", "StateShort");

            ViewData["StatusId"] = new SelectList(betterStatus, "Id", "StatusName");

            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Title, NameFirst, NameMiddle, NameLast, StatusId, OrganizationId, POCforOrganization")] People person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var detailedPerson = _context.Organization.OrderBy(o => o.OrganizationName).ThenBy(o => o.State.StateShort)
               .Include(p => p.State).Select(s => new
               {
                   OrganizationId = s.OrganizationId,
                   StateShort = s.OrganizationName + " - " + s.State.StateShort
               }).ToList();

            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "StateShort");

            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Label", person.StatusId);
            return View(person);

        }

        // GET: People/Edit
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var person = await _context.People.FindAsync(id);
            if(person == null)
            {
                return NotFound();
            }
            var detailedOrg = _context.Organization.OrderBy(o => o.OrganizationName).ThenBy(o => o.State.StateShort)
                  .Include(p => p.State).Select(s => new
                  {
                      OrganizationId = s.OrganizationId,
                      StateShort = s.OrganizationName + " - " + s.State.StateShort
                  }).ToList();

            ViewData["OrganizationId"] = new SelectList(detailedOrg, "OrganizationId", "StateShort");
            var betterStatus = _context.Status.OrderBy(s => s.StatusName);

            ViewData["StatusId"] = new SelectList(betterStatus, "Id", "StatusName", person.StatusId);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, NameFirst, NameMiddle, NameLast, StatusId, OrganizationId, POCforOrganization")]People person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganiztionId", "Label", person.OrganizationId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Label", person.StatusId);
                return View(person);
        }

        // GET: People/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var person = await _context.People
                 .Include(p => p.Organization)
                .Include(p => p.Assignments)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(p => p.Id == id);
            ViewBag.message = "";
            if (person ==null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var person = await _context.People.FindAsync(id);
                _context.People.Remove(person);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.message = "You must remove related records before removing this one.  It is in use.";
                return View();
            }
        }
       
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}