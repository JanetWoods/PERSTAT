using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models.ViewModels
{
    public class PeopleStatusOrganizationViewModel
    {
        public List<People> People { get; set; }
        public List<Organization> Organizations  { get; set; }

        private string _connectionString;
        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

    }
}
