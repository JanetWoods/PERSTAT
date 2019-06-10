using PERSTAT.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Missions
    {
        public int MissionId { get; set; }

        public string MissionTitle { get; set; }

        public string MissionDescription { get; set; }

        public int LocatioId { get; set; }
        public Locations Location { get; set; }

        [Display(Name = "Mission POC Id")]
        public int PeopleId { get; set; }

        [Display(Name ="MissionPOC")]
        public People MissionPOC { get; set; }

        public ICollection Assignments { get; set; }

        public ICollection<People> People { get; set; }

        public ICollection<CountyMissions> CountyMissions { get; set; }

    }
}
