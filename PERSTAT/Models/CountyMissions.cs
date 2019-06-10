using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models.ViewModels
{
    public class CountyMissions
    {
        public int Id { get; set; }
        public int CountyId { get; set; }
        public Counties County { get; set; }

        public int MissionId { get; set; }
        public Missions Mission { get; set; }

    }

}
