using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        public int IncidentTypeId { get; set; }
        public IncidentType Type { get; set; }

        public string IncidentDescription { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
