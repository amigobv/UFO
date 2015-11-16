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
    public class RestrictionDao : IDao<Restriction, int>
    {
        private const string SQL_COUNT =
            @"Select COUNT(idRestrictions) FROM Restrictions";

        private const string SQL_FIND_BY_ID =
            @"SELECT r.idRestrictions, r.start, r.stop, v.idVenue, v.label, v.maxSpectators, c.idCategory, c.label, l.idLocation, l.label " +
            @"FROM Restrictions as r, Venue as v, Category as c, Location as l " +
            @"WHERE r.venue = v.idVenue AND r.category = c.idCategory AND r.cLocation = l.idLocation AND r.idRestrictions = @id";

        private const string SQL_FIND_ALL =
            @"SELECT r.idRestrictions, r.start, r.stop, v.idVenue, v.label, v.maxSpectators, c.idCategory, c.label, l.idLocation, l.label " +
            @"FROM Restrictions as r, Venue as v, Category as c, Location as l " + 
            @"WHERE r.venue = v.idVenue AND r.category = c.idCategory AND r.cLocation = l.idLocation";

        private const string SQL_INSERT =
            @"INSERT INTO Restrictions " +
            @"VALUES (@start, @end, @venueId, @locationId, @categoryId);" +
            @"SELECT SCOPE_IDENTITY()";

        private const string SQL_UPDATE =
            @"UPDATE Restrictions " +
            @"SET start = @start, stop = @end, venue = @venueId, cLocation = @locationId, category = @categoryId " +
            @"WHERE idRestrictions = @id";

        private const string SQL_DELETE = @"DELETE FROM Restrictions WHERE idRestrictions = @id";

        private IDatabase _database;

        public RestrictionDao(IDatabase database)
        {
            _database = database;

        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public Restriction FindById(int id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.Int32, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new Restriction((int)reader[0],
                                          (DateTime)reader[1],
                                          (DateTime)reader[2],
                                          new Venue((int)reader[3],
                                                    (string)reader[4],
                                                    (int)reader[5],
                                                    new Location((string)reader[8],
                                                                 (string)reader[9])),
                                          new Category((string)reader[6],
                                                       (string)reader[7]));
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
                    restrictions.Add(new Restriction((int)reader[0],
                                                     (DateTime)reader[1],
                                                     (DateTime)reader[2],
                                                     new Venue((int)reader[3],
                                                               (string)reader[4],
                                                               (int)reader[5],
                                                               new Location((string)reader[8],
                                                                            (string)reader[9])),
                                                      new Category((string)reader[6],
                                                                   (string)reader[7])));
                }

                return restrictions;
            }
        }

        public bool Insert(Restriction o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@start", DbType.DateTime, o.Start);
            _database.DefineParameter(command, "@end", DbType.DateTime, o.End);
            _database.DefineParameter(command, "@venueId", DbType.Int32 , o.Venue.Id);
            _database.DefineParameter(command, "@locationId", DbType.Int32, o.Venue.Location.Id);
            _database.DefineParameter(command, "@categoryId", DbType.Int32, o.Category.Id);

            var id = _database.ExecuteScalar(command);
            o.Id = Convert.ToInt32(id.ToString());

            return id != null;
        }

        public bool Update(Restriction o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.Int32, o.Id);
            _database.DefineParameter(command, "@start", DbType.DateTime, o.Start);
            _database.DefineParameter(command, "@end", DbType.DateTime, o.End);
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
