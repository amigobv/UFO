using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;
using Ufo.DAL.Common.Dao;
using Ufo.DAL.Common.Domain;

namespace Ufo.DAL.SqlServer.Dao
{
    public class PerformanceDao : IDao<Performance, int>
    {
        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Performance " +
            @"WHERE idPerformance = @id";
            

        // TODO: check FIND_ALL query
        private const string SQL_FIND_ALL =
            @"SELECT * FROM Performance";

        private const string SQL_INSERT =
            @"INSERT INTO Performance " +
            @"VALUES (@date, @time, @artistId, @venueId, @locationId)";

        private const string SQL_UPDATE =
            @"UPDATE Performance " +
            @"SET date = @date, time = @time, artist = @artistId " +
            @"pVenue = @venueId, pLocation = @locationId " +
            @"WHERE idPerformance = @id";

        private const string SQL_DELETE = @"DELETE Performance WHERE idPerformance = @id";

        private IDatabase _database;

        public PerformanceDao(IDatabase database)
        {
            _database = database;
        }

        public IList<Performance> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var performancies = new List<Performance>();

                while (reader.Read())
                {
                    var artist = new ArtistDao(_database).FindById((int)reader["artistId"]);
                    var venue = new VenueDao(_database).FindById((int)reader["venueId"], (string)reader["location"]); 

                    performancies.Add(new Performance((int)reader["idPerformance"],
                                                      (DateTime)reader["date"],            // TODO: check type
                                                      (DateTime)reader["time"],             // TODO: check type
                                                      artist,
                                                      venue));     
                }

                return performancies;
            }
        }

        public Performance FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    var artist = new ArtistDao(_database).FindById((int)reader["artistId"]);
                    var venue = new VenueDao(_database).FindById((int)reader["venueId"], (string)reader["location"]); 

                    return new Performance((int)reader["idPerformance"],
                                           (DateTime)reader["date"],            // TODO: check type
                                           (DateTime)reader["time"],             // TODO: check type
                                           artist,
                                           venue);
                }

                return null;
            }
        }

        public bool Insert(Performance o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@date", DbType.DateTime, o.Date);     // TODO: check type
            _database.DefineParameter(command, "@time", DbType.DateTime, o.Time);       // TODO: check type
            _database.DefineParameter(command, "@artistId", DbType.String, o.Artist.Id);
            _database.DefineParameter(command, "@venueId", DbType.Int32, o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(Performance o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@date", DbType.DateTime, o.Date);     // TODO: check type
            _database.DefineParameter(command, "@time", DbType.Time, o.Time);   // TODO: check type
            _database.DefineParameter(command, "@artistId", DbType.String, o.Artist.Id);
            _database.DefineParameter(command, "@venueId", DbType.Int32, o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
