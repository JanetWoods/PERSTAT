using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public AssignmentController(ApplicationDbContext context,
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

        // GET: Assignment
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assignment
                .Include(a => a.People)
                .Include(a => a.People.Status)
                .Include(a => a.People.Organization)
                .Include(a => a.Mission)
                .Include(a => a.Incident)
                .Include(a => a.Location)
                .Where(p => p.DateEnd > (DateTime.Now).AddDays(-1))
                .OrderByDescending(p => p.DateEnd);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Assignment/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = await _context.Assignment
                .Include(a => a.People)
                .Include(a => a.Mission)
                .Include(a => a.Incident)
                .Include(a => a.Location)
                .FirstAsync(a => a.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }
        public async Task<IActionResult> GetPeopleByMission(int id)
        {
            var groupByM = _context.Assignment
                .Include(p => p.People)
                .Include(p => p.Mission)
                .Include(p => p.Location)
                .Include(p => p.People.Status)
                .Include(p => p.People.Organization)
                .Where(p => p.MissionId == id && p.DateEnd > (DateTime.Now).AddDays(-1))
                .OrderByDescending(p => p.DateEnd);

            var count = groupByM.Count();

            if (groupByM == null)
            {
                return NotFound();
            }
            return View(await groupByM.ToListAsync());
        }
        public async Task<IActionResult> GetPeopleByLocation(int id)
        {
            var groupByM = _context.Assignment
                .Include(p => p.People)
                .Include(p => p.Mission)
                .Include(p => p.Location)
                .Include(p => p.People.Status)
                .Include(p => p.People.Organization)
                .Where(p => p.LocationId == id && p.DateEnd > (DateTime.Now).AddDays(-1))
                .OrderByDescending(p => p.DateEnd);

            var count = groupByM.Count();

            if (groupByM == null)
            {
                return NotFound();
            }
            return View(await groupByM.ToListAsync());
        }

        // GET: Assignment/Create
        [Authorize]
        public IActionResult Create()
        {
            var detailedLocation = _context.Locations
                .Include(l => l.State).Select(s => new
                {
                    LocationId = s.LocationId,
                    LocationString = s.State.StateShort + " " + s.LocationCity + " ( " + s.LocationDetail + ")"
                }).ToList();

            var detailedPerson = _context.People
                .Include(p => p.Organization).Select(i => new
                {
                    PeopleId = i.Id,
                    PeopleString = i.NameFirst + " " + i.NameLast + " ( " + i.Organization.OrganizationName + ")"
                }).ToList();
            var detailedMission = _context.Missions.Select(m => new
            {
                MissionId = m.Id,
                MissionString = m.MissionTitle
            }).ToList();

            var detailedIncident = _context.Incident
                .Include(i => i.IncidentTypeId)
                .Include(t => t.Type)
                .Select(t => new
                {
                    IncidentId = t.Type,
                    IncidentString = t.Type.TypeIncident
                }).ToList();



            ViewData["PeopleId"] = new SelectList(detailedPerson, "PeopleId", "PeopleString");
            ViewData["LocationId"] = new SelectList(detailedLocation, "LocationId", "LocationString");
            ViewData["MissionId"] = new SelectList(detailedMission, "MissionId", "MissionString");
            ViewData["IncidentId"] = new SelectList(detailedIncident, "IncidentId", "IncidentString");
            ViewBag.message = "";
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("PeopleId, MissionId, DateStart, DateEnd, LocationId, IncidentId")]Assignment assignment)
        {

            var detailedLocation = _context.Locations
            .Include(l => l.State).Select(s => new
            {
                LocationId = s.LocationId,
                LocationString = s.State.StateShort + " " + s.LocationCity + " ( " + s.LocationDetail + ")"
            }).ToList();

            var detailedPerson = _context.People
                .Include(p => p.Organization).Select(i => new
                {
                    PeopleId = i.Id,
                    PeopleString = i.NameFirst + " " + i.NameMiddle + " " + i.NameLast + " ( " + i.Organization.OrganizationName + ")"
                }).ToList();
            var detailedMission = _context.Missions.Select(m => new
            {
                MissionId = m.Id,
                MissionString = m.MissionTitle
            }).ToList();

            var detailedIncident = _context.Incident
               .Include(i => i.IncidentTypeId)
               .Include(t => t.Type)
               .Select(t => new
               {
                   IncidentId = t.Type,
                   IncidentString = t.Type.TypeIncident
               }).ToList();

            ViewData["PeopleId"] = new SelectList(detailedPerson, "PeopleId", "PeopleString");
            ViewData["LocationId"] = new SelectList(detailedLocation, "LocationId", "LocationString");
            ViewData["MissionId"] = new SelectList(detailedMission, "MissionId", "MissionString");
            ViewData["IncidentId"] = new SelectList(detailedIncident, "IncidentId", "IncidentString");

            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);


        }


        [Authorize]
        // GET: Assignment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            var detailedLocation = _context.Locations
            .Include(l => l.State).Select(s => new
            {
                LocationId = s.LocationId,
                LocationString = s.State.StateShort + " " + s.LocationCity + " ( " + s.LocationDetail + ")"
            }).ToList();

            var detailedPerson = _context.People
                .Include(p => p.Organization).Select(i => new
                {
                    PeopleId = i.Id,
                    PeopleString = i.NameFirst + " " +  " " + i.NameLast + " ( " + i.Organization.OrganizationName + ")"
                }).ToList();
            var detailedMission = _context.Missions.Select(m => new
            {
                MissionId = m.Id,
                MissionString = m.MissionTitle
            }).ToList();

            var detailedIncident = _context.Incident
               .Include(i => i.Type)
               .Select(t => new
               {
                   IncidentTypeId = t.IncidentTypeId,
                   IncidentString = t.Type
               }).ToList();

            ViewData["PeopleId"] = new SelectList(detailedPerson, "PeopleId", "PeopleString");
            ViewData["LocationId"] = new SelectList(detailedLocation, "LocationId", "LocationString");
            ViewData["MissionId"] = new SelectList(detailedMission, "MissionId", "MissionString");
            ViewData["IncidentId"] = new SelectList(detailedIncident, "IncidentId", "IncidentString");
            return View(assignment);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId, PeopleId, LocationId, MissionId, DateStart, DateEnd, IncidentId")]Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
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
            var detailedLocation = _context.Locations
             .Include(l => l.State).Select(s => new
             {
                 LocationId = s.LocationId,
                 LocationString = s.State.StateShort + " " + s.LocationCity + " ( " + s.LocationDetail + ")"
             }).ToList();

            var detailedPerson = _context.People
                .Include(p => p.Organization).Select(i => new
                {
                    PeopleId = i.Id,
                    PeopleString = i.NameFirst + " " + " " + i.NameLast + " ( " + i.Organization.OrganizationName + ")"
                }).ToList();
            var detailedMission = _context.Missions.Select(m => new
            {
                MissionId = m.Id,
                MissionString = m.MissionTitle
            }).ToList();

            var detailedIncident = _context.Incident
               .Include(i => i.IncidentTypeId)
               .Include(t => t.Type)
               .Select(t => new
               {
                   IncidentId = t.Type,
                   IncidentString = t.Type.TypeIncident
               }).ToList();

            ViewData["PeopleId"] = new SelectList(detailedPerson, "PeopleId", "PeopleString");
            ViewData["LocationId"] = new SelectList(detailedLocation, "LocationId", "LocationString");
            ViewData["MissionId"] = new SelectList(detailedMission, "MissionId", "MissionString");
            ViewData["IncidentId"] = new SelectList(detailedIncident, "IncidentId", "IncidentString");
            return View(assignment);
        }
      


        [Authorize]
        // GET: Assignment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = await _context.Assignment
                .Include(p => p.People)
                .Include(p => p.Mission)
                .Include(p => p.Location)
                .Include(p => p.People.Status)
                .FirstOrDefaultAsync(p => p.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var assignment = await _context.Assignment.FindAsync(id);
                _context.Assignment.Remove(assignment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult GetAssignmentsByPerson(int id)
        {

            var assigments = _context.Assignment
                .Where(a => a.DateEnd > (DateTime.Now).AddDays(-1))
                .Include(a => a.People)
                .Include(a => a.Mission)
                .Include(a => a.Location)
                .Where(a => a.PeopleId == id)
                .ToList();

            var count = assigments.Count();

            if (assigments == null)
            {
                return NotFound();
            }
            return View(assigments);
        }

        public async Task<IActionResult> GetAssignmentsByStatus(int id)
        {
            var groupByStatus = _context.Assignment
                .Include(p => p.People)
                .Include(p => p.Mission)
                .Include(p => p.Location)
                .Include(p => p.Location.State)
                .Include(p => p.People.Status)
                .Include(p => p.People.Organization)
                .Where(p => p.People.StatusId == id && p.DateEnd > (DateTime.Now).AddDays(-1))
                .OrderByDescending(p => p.DateEnd);

            var count = groupByStatus.Count();

            if (groupByStatus == null)
            {
                return NotFound();
            }
            return View(await groupByStatus.ToListAsync());
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignment.Any(a => a.AssignmentId == id);
        }

    }
}

