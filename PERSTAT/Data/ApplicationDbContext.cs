using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PERSTAT.Models;
using PERSTAT.Models.ViewModels;

namespace PERSTAT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Counties> Counties { get; set; }

        public DbSet<Incident> Incident { get; set; }

        public DbSet<IncidentType> IncidentType { get; set; }

        public DbSet<Locations> Locations { get; set; }

        public DbSet<Missions> Missions { get; set; }
        public DbSet<Organization> Organization { get; set; }

        public DbSet<People> People { get; set; } 
        public DbSet<States> States { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<CountyMissions> CountyMissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


    }
}
