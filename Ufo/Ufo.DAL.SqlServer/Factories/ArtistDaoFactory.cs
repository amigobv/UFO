using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.SqlServer.Factories
{
    public static class ArtistDaoFactory
    {
        private static ArtistDao artistDao;

        public static ArtistDao GetArtistDao()
        {
            if (artistDao == null)
                artistDao = new ArtistDao(new Database(DbConfiguration.ConnectionString));

            return artistDao;
        }
    }
}
