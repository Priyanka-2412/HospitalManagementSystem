using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Util
{
    public class DBConnectionUtil
    {
        public static string GetConnectionString()
        {
            return "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=HospitalManagementSystem; Integrated Security=True;";
        }
    }
}
