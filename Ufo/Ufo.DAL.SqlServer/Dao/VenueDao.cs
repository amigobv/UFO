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
    public class VenueDao : IDao<Venue, int>
    {
        private const string SQL_COUNT =
            @"Select COUNT(idVenue) FROM Venue";

        private const string SQL_FIND_BY_ID =
            @"SELECT v.idVenue, v.label, v.maxSpectators, l.idLocation, l.label " +
            @"FROM Venue as v, Location as l " +
            @"WHERE v.idVenue = @idVenue AND v.location = l.idLocation";

        private const string SQL_FIND_ALL =
            @"SELECT v.idVenue, v.label, v.maxSpectators, v.location, l.label " +
            @"FROM Venue as v, Location as l " +
            @"WHERE v.location = l.idLocation";

        private const string SQL_INSERT =
            @"INSERT INTO Venue " +
            @"VALUES (@idVenue, @label, @maxSpectators, @location)";

        private const string SQL_UPDATE =
            @"UPDATE Venue " +
            @"SET label = @label, location = @location, maxSpectators = @maxSpectators " +
            @"WHERE idVenue = @idVenue AND location = @idLocation";

        private const string SQL_DELETE = @"DELETE FROM Venue WHERE idVenue = @idVenue AND location = @idLocation";

        private IDatabase _database;

        public VenueDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public IList<Venue> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var venues = new List<Venue>();

                while (reader.Read())
                {
                    venues.Add(new Venue((int)reader.GetInt32(0),
                                         (string)reader.GetString(1),
                                         (int)reader.GetInt32(2),
                                         new Location((string)reader.GetString(3), (string)reader.GetString(4))));
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
                    return new Venue((int)reader.GetInt32(0),
                                     (string)reader.GetString(1),
                                     (int)reader.GetInt32(2),
                                     new Location((string)reader.GetString(3), (string)reader.GetString(4)));
                }

                return null;
            }
        }

        public bool Insert(Venue o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@idVenue", DbType.Int32, o.Id);
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

        public Venue FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
