using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public string StatusDescription { get; set; }

        public ICollection<People> People { get; set; }
    }
}
