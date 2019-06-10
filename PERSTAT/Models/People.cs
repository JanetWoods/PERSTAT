using PERSTAT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class People
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string NameFirst { get; set; }

        public string NameMiddle { get; set; }

        public string NameLast { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }


        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public bool POCforOrganization { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

      

    
    }

}
