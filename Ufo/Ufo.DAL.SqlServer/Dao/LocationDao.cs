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
    public class LocationDao : IDao<Location, string>
    {
        private const string SQL_COUNT =
            @"Select COUNT(idLocation) FROM Location";

        private const string SQL_FIND_BY_ID =
            @"SELECT * " +
            @"FROM Location " +
            @"WHERE idLocation = @id";

        private const string SQL_FIND_ALL =
            @"SELECT * FROM Location ";

        private const string SQL_INSERT =
            @"INSERT INTO Location " +
            @"VALUES (@id, @label)";

        private const string SQL_UPDATE =
            @"UPDATE Location " +
            @"SET label = @label " +
            @"WHERE idLocation = @id";

        private const string SQL_DELETE = @"DELETE FROM Location WHERE idLocation = @id";

        private IDatabase _database;

        public LocationDao(IDatabase database)
        {
            _database = database;
        }

        public int Count()
        {
            var command = _database.CreateCommand(SQL_COUNT);

            return (int)_database.ExecuteScalar(command);
        }

        public Location FindById(string id)
        {
            var command = _database.CreateCommand(SQL_FIND_BY_ID);
            _database.DefineParameter(command, "@id", DbType.String, id);

            using (var reader = _database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return new Location((string)reader["idLocation"], (string)reader["label"]);
                }

                return null;
            }
        }

        public IList<Location> FindAll()
        {
            var command = _database.CreateCommand(SQL_FIND_ALL);

            using (var reader = _database.ExecuteReader(command))
            {
                var locations = new List<Location>();

                while (reader.Read())
                {
                    locations.Add(new Location((string)reader["idLocation"], (string)reader["label"]));
                }

                return locations;
            }
        }

        public bool Insert(Location o)
        {
            var command = _database.CreateCommand(SQL_INSERT);
            _database.DefineParameter(command, "@id", DbType.String, o.Id);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);


            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Update(Location o)
        {
            var command = _database.CreateCommand(SQL_UPDATE);
            _database.DefineParameter(command, "@id", DbType.String, o.Id);
            _database.DefineParameter(command, "@label", DbType.String, o.Label);

            return _database.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(string id)
        {
            var command = _database.CreateCommand(SQL_DELETE);
            _database.DefineParameter(command, "@id", DbType.String, id);

            return _database.ExecuteNonQuery(command) == 1;
        }
    }
}
