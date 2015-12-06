using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class PerformanceDaoFactory
    {
        private static PerformanceDao performanceDao;

        public static PerformanceDao GetPerformanceDao()
        {
            if (performanceDao == null)
                performanceDao = new PerformanceDao(new Database(DbConfiguration.ConnectionString));

            return performanceDao;
        }
    }
}
