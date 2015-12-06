using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class LocationDaoFactory
    {
        private static LocationDao locationDao;

        public static LocationDao GetLocationDao()
        {
            if (locationDao == null)
                locationDao = new LocationDao(new Database(DbConfiguration.ConnectionString));

            return locationDao;
        }
    }
}
