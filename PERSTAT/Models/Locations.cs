using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Locations
    {
        public int LocationId { get; set; }

        public string LocationCity { get; set; }

        public string LocationDetail { get; set; }

        public int StateId { get; set; }
        public States State { get; set; }

        public int CountyId { get; set; }
        public Counties County { get; set; }

        public ICollection<Missions> Missions { get; set; }
    }
}
