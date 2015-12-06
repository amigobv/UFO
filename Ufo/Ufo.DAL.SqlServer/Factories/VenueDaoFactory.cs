using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class VenueDaoFactory
    {
        private static VenueDao venueDao;

        public static VenueDao GetVenueDao()
        {
            if (venueDao == null)
                venueDao = new VenueDao(new Database(DbConfiguration.ConnectionString));

            return venueDao;
        }
    }
}
