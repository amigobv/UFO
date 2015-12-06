using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class RestrictionDaoFactory
    {
        private static RestrictionDao restrictionDao;

        public static RestrictionDao GetRestrictionDao()
        {
            if (restrictionDao == null)
                restrictionDao = new RestrictionDao(new Database(DbConfiguration.ConnectionString));

            return restrictionDao;
        }
    }
}
