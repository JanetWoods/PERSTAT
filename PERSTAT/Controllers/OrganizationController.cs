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
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public OrganizationController(ApplicationDbContext context,
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


        // GET: Organization
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var applicationDbContext = _context.Organization
                .Include(p => p.State)
                .Include(p => p.People)
                .OrderBy(p => p.OrganizationName)
                .ThenBy(p => p.State.StateShort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateShort");
            return View();
        }

        // GET: Organization/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            return View();
        }

        // POST: Organization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("OrganizationName, OrganizationStreet1, OrganizationStreet2, City, StateId")]Organization organization)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(organization);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
                return View(organization);
            }
            catch
            {
                return View();
            }
        }

        // GET: Organization/Edit
        [Authorize]
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var org = await _context.Organization.FindAsync(id);
            if (org == null)
            {
                return NotFound();
            }
            return View(org);
        }



        // POST: Organization/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("int OrganizationId, OrganizationName, OrganizationStreet1, OrganizationStreet2, City, StateId")]Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrganizationId))
                    {
                        return NotFound();
                    }

                }

                return RedirectToAction(nameof(Index));
            }
            return View(organization);

        }

        // GET: Organization/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var org = await _context.Organization
                .FirstOrDefaultAsync(s => s.OrganizationId == id);
            if (org == null)
            {
                return NotFound();
            }
            return View(org);
        }


        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int OrganizationId)
        {
            try
            {
                var org = await _context.Organization.FindAsync(OrganizationId);
                _context.Organization.Remove(org);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool OrganizationExists(int id)
        {
            return _context.Organization.Any(e => e.OrganizationId == id);
        }
    }

}