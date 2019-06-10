using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
       
        public int PeopleId { get; set; }

        public People Person { get; set; }

        public int MissionId { get; set; }

        public Missions Mission { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public int IncidentId { get; set; }

        public Incident Incident { get; set; }

    

    }
}
