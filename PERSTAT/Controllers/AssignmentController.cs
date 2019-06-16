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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assignment
                .Include(a => a.People)
                .Include(a => a.Mission)
                .Include(a => a.Incident)
                .Include(a => a.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignment/Details/5
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
                .Where(p => p.MissionId == id);
            if(groupByM == null)
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
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("PeopleId, MissionId, DateStart, DateEnd, LocationId, IncidentId")]Assignment assignment)
        {
            if(ModelState.IsValid)
            
            {
                    _context.Add(assignment);
                    await _context.SaveChangesAsync();
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
            return View(assignment);
        }


        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assignment/Edit/5
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

        // GET: Assignment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assignment/Delete/5
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