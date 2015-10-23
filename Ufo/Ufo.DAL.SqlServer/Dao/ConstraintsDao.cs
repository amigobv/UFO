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
    public class ConstraintsDao : IDao<Restriction, int>
    {
        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Constraints " +
            @"WHERE idConstraints = @id";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM Constraints ";

        private const string SQL_INSERT =
            @"INSERT INTO Constraints " +
            @"VALUES (@start, @end, @venueId, @locationId, @categoryId)";

        private const string SQL_UPDATE =
            @"UPDATE Constraints " +
            @"SET start = @start, stop = @stop, venue = @venueId, cLocation = @locationId, category = @categoryId " +
            @"WHERE idConstraints = @id";

        private const string SQL_DELETE = @"DELETE Constraints WHERE idConstraints = @id";

        private IDatabase _database;

        public ConstraintsDao(IDatabase database)
        {
            _database = database;

        }

        public Restriction FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    var venue = new VenueDao(_database).FindById((int)reader["venue"], (string)reader["cLocation"]);
                    var category = new CategoryDao(_database).FindById((string)reader["category"]);

                    return new Restriction((int)reader["idConstraints"],
                                          (DateTime)reader["start"],
                                          (DateTime)reader["end"],
                                          venue,
                                          category);
                }

                return null;
            }
        }

        public IList<Restriction> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                IList<Restriction> restrictions = new List<Restriction>();

                while (reader.Read())
                {
                    var venue = new VenueDao(_database).FindById((int)reader["venue"], (string)reader["cLocation"]);
                    var category = new CategoryDao(_database).FindById((string)reader["category"]);

                    restrictions.Add(new Restriction((int)reader["idConstraint"],
                                                     (DateTime)reader["start"],
                                                     (DateTime)reader["stop"],
                                                     venue,
                                                     category));
                }

                return restrictions;
            }
        }

        public bool Insert(Restriction o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@start", DbType.DateTime, o.Start);
            _database.DefineParameter(command, "@stop", DbType.DateTime, o.End);
            _database.DefineParameter(command, "@venueId", DbType.Int32 , o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);
            _database.DefineParameter(command, "@categoryId", DbType.Int32, o.Category.Id);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(Restriction o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.String, o.Id);
            _database.DefineParameter(command, "@start", DbType.DateTime, o.Start);
            _database.DefineParameter(command, "@stop", DbType.DateTime, o.End);
            _database.DefineParameter(command, "@venueId", DbType.Int32, o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);
            _database.DefineParameter(command, "@categoryId", DbType.Int32, o.Category.Id);

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
