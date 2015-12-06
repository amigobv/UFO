using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.SqlServer
{
    public static class DbConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = H:\Semester5\SWK5\Project\Ufo\Ufo.DAL.SqlServer\UfoDb.mdf; Integrated Security = True";
            }
        }
    }
}
