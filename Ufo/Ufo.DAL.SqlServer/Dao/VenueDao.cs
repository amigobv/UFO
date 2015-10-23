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
    public class VenueDao
    {
        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Venue " +
            @"WHERE idVenue = @idVenue AND location = @idLocation";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM Venue";

        private const string SQL_INSERT =
            @"INSERT INTO Venue " +
            @"VALUES (@label, @location, @maxSpectators)";

        private const string SQL_UPDATE =
            @"UPDATE Venue " +
            @"SET label = @label, location = @location, maxSpectators = @maxSpectators " +
            @"WHERE idVenue = @idVenue AND location = @idLocation";

        private const string SQL_DELETE = @"DELETE Venue WHERE idVenue = @idVenue AND location = @idLocation";

        private IDatabase _database;

        public VenueDao(IDatabase database)
        {
            _database = database;
        }

        public IList<Venue> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var venues = new List<Venue>();

                while (reader.Read())
                {
                    var location = new LocationDao(_database).FindById((string)reader["location"]);
                    venues.Add(new Venue((int)reader["idVenue"],
                                         (string)reader["label"],
                                         location,
                                         (int)reader["maxSpectators"]));
                }

                return venues;
            }
        }

        public Venue FindById(int venueId, string locationId)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@idVenue", DbType.Int32, venueId);
            _database.DefineParameter(command, "@idLocation", DbType.String, locationId);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    var location = new LocationDao(_database).FindById((string)reader["location"]);
                    return new Venue((int)reader["idVenue"],
                                     (string)reader["label"],
                                     location,
                                     (int)reader["maxSpectators"]);
                }

                return null;
            }
        }

        public bool Insert(Venue o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);
            _database.DefineParameter(command, "@location", DbType.String, o.Location.Id);
            _database.DefineParameter(command, "@maxSpectators", DbType.Int32, o.MaxSpectators);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(Venue o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@idVenue", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@idLocation", DbType.Int32, o.Location.Id);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);
            _database.DefineParameter(command, "@location", DbType.String, o.Location.Id);
            _database.DefineParameter(command, "@maxSpectators", DbType.Int32, o.MaxSpectators);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int idVenue, string idLocation)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@idVenue", DbType.Int32, idVenue);
            _database.DefineParameter(command, "@idLocation", DbType.String, idLocation);

            return _database.ExecuteNonQuery(command) == 1;
        }

    }
}
